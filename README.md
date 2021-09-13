# librarymigration
Contains examples of how to create .NetS and .Net5 builds of older .NetF class libraries.

The "SomeLibrary" example shows how we can create a single library project that can create build outputs for a set of chosen targets and how those build outputs can be easily consumed.

This sample deals with a common case - take an existing library that targets .Net Framework and make that functionality available as .Net Standard even when there might be bits of code in the library that cannot be built against .Net Standard (that is to say code that uses classes etc that are not part of .Net Standard).

.Net Standard implements a lot of .Net 4.7.2 but not all and a lot of .Net5 but not all so from time to time we hit this and the code cannot be built as-is for .Net Standard.

A good example is HttpContext.Current as found in many ASP.NET apps and libraries, the System.Web functionality (which is where HttpContext is situated) simply does not exist as part of .Net5 and there is no direct replacement.

So the approach that seems ideal is to put all of the code that can be built against .Net Standard into a .Net Standard project and remove any code that does not (doing this in such a way that the original code can be built without these odd bits needing to be present). Then we have a .Net Standard package that does most of what the old one did, but can be used by any existing .Net Framework app or any new .Net5/.NetCore app.

Then we adjust that project to add two additional build targets - one for .Net Framework and the other for .Net5/.NetCore - and then use conditional compilation to ensure that as each of these additional build targets is built only the target specific code is seen and included in the build.

The results of this is:

1. We have a single project still.
2. All code that can be built to .Net Standards is included in the project.
3. All code that is target specific (that is must be written differently on .NetF and .NetC) is in a folder "Targeted".
4. Code in that folder is annotated as needed with #IF using the predefined build target names provided by MS.
5. Libraries that are needed by the targeted builds themselves are defined on a per-target basis using standard MS build directives (see the library project .csproj file).
6. The end result is a SINGLE nuget package.
7. Finally specific target consumers can simply include the package and VS ensure that the correct targeted build is seen by the consuming app.

I found some pretty helpful information [here too](https://blog.inedo.com/dotnet/nuget-library-migration-strategies).

