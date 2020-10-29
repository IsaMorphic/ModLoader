# Introduction

Hello! I'm known on the internet as Yodadude2003, but for simplicity's sake you can also call me Ian.  I'm the founder and owner of Chosen Few Software, as well as the sole developer of ModLoader.  

Being the developer of this tool, it is my belief that I have a duty to explain how it is intended to be used so that you, the user, may use it to its fullest potential.  Before I get into the nitty gritty details, though, I do think that some clarifications are in order.  Most importantly, is the "problem statement".  Every tool I write is built to serve a purpose; to solve a problem.  Clarifying to users what exactly this problem is can help them decide whether the tool will ultimately help them or not.  So let's do it!

## A Modder in Peril

I originally started developing ModLoader because I was having major problems with the way I managed all the different modifications (hereby referred to as "mods") to my favorite games.  Originally, I had decided that the best existing solution was source/version control.  This was fine, but almost right away problems arose.  

First of all, I actually had to "version" my copy of the game.  This meant that every time I made a change to one of my mods, I had to "check it in" to the version control software.  Now, with text files, this isn't normally a problem, as the tools I was using were very well optimized for that purpose.  

But games are mostly binary data, which is very dense and hard to version, because the differences between two copies of the same file can be interpreted in many ways.  

Because of this, each time I make a tiny change to an executable file, or have to change a sound effect, the tool I'm using has to store a whole new copy of it!  These copies add up very quickly, especially if you're managing different "branches" that contain different changes to the base game.  

That's not to mention the fact that I don't even want to version my mods!! Its a massive waste of space.  

The second problem I had with existing version control solutions was the fact that it was very inconvenient to switch between different mods I was working on.  Sometimes I would end up accidentally making changes to the game on the wrong branch, which made it very difficult to then transfer that work over (and I would often end up losing everything that I did!).  

Thirdly, if I wanted to test out multiple mods at the same time, in effect "merging" them, I had to create a new branch and check in those new changes!!!

What I wanted was a very easy way to, in effect, enable and disable any and all of my mods on demand, and load them with the click of a single button.  

This finally leads us to ModLoader's problem statement:

## Problem statement

I need a way to easily and intuitively manage different sets of changes to a single "base" filesystem.  

However, existing solutions to similar problems are unsatisfactory because they:

1. Are not very well optimized for binary files, and as a result waste massive amounts of disk space trying to keep track of changes to every file in a given mod.  
2. Make it very difficult to switch between different versions of the same filesystem
3. Make it very difficult to merge several versions of the same filesystem

## Evaluation

So, dear user, if the solution to this problem is what you're looking for, you have come to the right place, because ModLoader's rich set of features are built exclusively around this premise, making it a light-weight, focused, and intuitive way to manage your mods.  If you are unsure of whether or not this tool will work for your purposes, try to keep reading for a little bit and understand the specific features of the tool before you totally give up on it.  