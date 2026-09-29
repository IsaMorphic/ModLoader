using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core.Utilities
{
    public class DiffBuilder
    {
        private enum Operation
        {
            Remove,
            Replace,
            Add
        }

        private class Line
        {
            public Operation Operation { get; }

            public string Content { get; }

            public Line(Operation operation, string content)
            {
                Operation = operation;
                Content = content;
            }
        }

        private class Hunk
        {
            public int Offset { get; }

            public int Length => Lines.Count;

            public List<Line> Lines { get; }

            public Hunk(int offset)
            {
                Offset = offset;
                Lines = new();
            }
        }

        private string PathToOriginal { get; }
        private string PathToModded { get; }

        public DiffBuilder(string pathToOriginal, string pathToModded)
        {
            PathToOriginal = pathToOriginal;
            PathToModded = pathToModded;
        }

        public async Task BuildAsync(string outputPath)
        {
            string[] originalLines = await File.ReadAllLinesAsync(PathToOriginal);
            string[] moddedLines = await File.ReadAllLinesAsync(PathToModded);

            List<Hunk> hunks = new(); Hunk currHunk = null;

            int i;
            for (i = 0; i < Math.Min(originalLines.Length, moddedLines.Length) - 1; i++)
            {
                if (originalLines[i] != moddedLines[i])
                {
                    currHunk ??= new Hunk(i);
                    currHunk.Lines.Add(new Line(Operation.Replace, moddedLines[i]));
                }
                else if (currHunk != null)
                {
                    hunks.Add(currHunk);
                    currHunk = null;
                }
            }

            currHunk = new Hunk(i);
            hunks.Add(currHunk);

            if (moddedLines.Length > originalLines.Length)
            {
                for (; i < moddedLines.Length; i++)
                {
                    currHunk.Lines.Add(new Line(Operation.Add, moddedLines[i]));
                }
            }
            else 
            {
                for (; i < originalLines.Length; i++)
                {
                    currHunk.Lines.Add(new Line(Operation.Remove, null));
                }
            }

            using (StreamWriter writer = File.CreateText(outputPath))
            {
                foreach (var hunk in hunks)
                {
                    await writer.WriteLineAsync($": {hunk.Offset}");
                    foreach (var line in hunk.Lines)
                    {
                        switch (line.Operation)
                        {
                            case Operation.Remove:
                                await writer.WriteLineAsync($"- {line.Content}");
                                break;
                            case Operation.Replace:
                                await writer.WriteLineAsync($"| {line.Content}");
                                break;
                            case Operation.Add:
                                await writer.WriteLineAsync($"+ {line.Content}");
                                break;
                        }
                    }
                }
            }
        }
    }
}
