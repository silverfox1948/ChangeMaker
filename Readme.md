# ChangeMaker

## Purpose
This application was done as part of an interview process for a new job. The test was to create a small application that would count the different ways that change could be made for any given amount with a given set of denominations. Then explain how to use the program.

This application, and this readme.md file accomplish both part of the test. I actually put themm up here as an easy way to allow the interviewer/reviewer to accesss the code, but anyone else is free to use it for whatever legal purpose they may have.

## How to build the application
First, download the solution files or pull from the repository.

Note that I've used a couple of NuGet packages which were not checked in, so do a restore of NuGet packages.

Build it. It is created using VS 2017 Community Edition, so should work for most of the Visual Studio versions out in the wild.

## How to run the application
This application accepts 3 parameters:
* -v mere presence indicates a log file should be created. It is created in a /logs sub-directory found in the same directory as the folder from which the application is run.
* -a the actual amount for which change is being counted. A positive integer number is expected.

* -d a space-separated list of integer denominations to be assumed available for making change

There is no specific order of entry of these parameters thanks to one of the NuGet packages I found & used (more about this below).
There is no checking that the denominations are real currency values - any space-separated list of positive whole integers will do, e.g. 2 3 7 15 will work. However, 1.5, 3, 9 will not. It does not blow up gracefully, however. More about that below.

As example, to log how many ways can 97 be constructed using the denominations of 2, 3, 7, 15:

```ChangeMaker.exe -v -a 97 -d 2 3 7 15```

Note that you can enter these same parameters into the command line arguments window of the Debug tab of the program properies editor:
![Runparameters](ChangeMaker/runparameters.bmp)

This will give you an easy way to run the application in debug from within VS.

## How it works
The application relies on recursion and 3 integer arrays:
*  ```int[] denomArray;``` holds a list of entered denominations sorted in descending order
* ```int[] maxCoeffArray;``` holds a list of the maximum coefficients for each denomination in denomArray. If a denomination has a value of 1, the maximum is set to 1 (more about this below)
*```int[] currCoeffArray;``` holds a transitory list of the current coefficients for  each domination. 

As example, for
```ChangeMaker.exe -a 27 -d 1 5 20 30``` 
* the denomArray values will be [30, 20, 5, 1]
* the maxCoeffArray values will be [0, 1, 5, 1]
* As the arrays are iterated through recursively the currCoeffAray will progress from [0,0,0,0] => [0,0,0,1] => [0,0,1,0] => [0,0,1,1] => ... [0, 1, 5, 1]. Yes, this is inefficient. Again, more about this below.

At






 