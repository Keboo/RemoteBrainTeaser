# RemoteBrainTeaser

## Spoiler Alert - this branch contains the solution ##

To [quote Randall Munroe](http://xkcd.com/356/)
> There's a certain type of brain that's easily disabled. If you show it an interesting problem, it involuntarily drops everything else to work on it

This is a simple brain teaser in C# that asks you to modify the return value of a couple methods.
There are two unit tests. Each calls a method on the TestMe class. However, at first glance the assertions in the unit test do not appear to match the code.

### Rules
1. No changes are allowed to UnitTests.cs (this applies to the entire file not just the UnitTest class).
2. No pre/post build steps. This can be done with only C# code.
3. No IL manipulation.
4. You are free to make any modifications outside the UnitTests.cs file that you see fit.

### How about some hints?
##### Hint 1 - just a little something to get you pointed in the right direction.
[Link 1](https://msdn.microsoft.com/en-us/library/wa80x488.aspx) [Link 2](https://msdn.microsoft.com/en-us/library/system.contextboundobject(v=vs.110).aspx)

##### Hint 2 - this will give you all the pieces you need
[Link 1](https://msdn.microsoft.com/en-us/library/system.runtime.remoting.contexts.contextattribute(v=vs.110).aspx) [Link 2](https://msdn.microsoft.com/en-us/library/system.runtime.remoting.contexts.icontributeobjectsink(v=vs.110).aspx) [Link 3](https://msdn.microsoft.com/en-us/library/system.runtime.remoting.messaging.imessagesink(v=vs.110).aspx)

### Solution
You can find a solution [here](https://github.com/Keboo/RemoteBrainTeaser/tree/solution), however I recommend giving the problem a shot before jumping straight to solution.
I welcome any pull requests that provide alternate solutions, extra points for documentation that explain of why they work.

### But Why?
Because brain teasers are fun and I love C#. As a professional developer I love learning the details of how my favorite language and its compiler work. 
*I do __not__ recommend that anyone write code like this in a production application. This type of code is best left to brain teasers.*
