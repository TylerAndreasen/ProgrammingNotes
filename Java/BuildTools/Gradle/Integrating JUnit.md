# Integrating JUnit into Gradle

I have previously tried to integrate JUnit 4 into Gradle with no success. Ultimately, JUnit is a Testing Library for Java, and Gradle is a build system.

When I run the command `gradle test` command I get this output
```bash
$ gradle test
Calculating task graph as no cached configuration is available for tasks: test

> Configure project :
e: file:///C:/Users/CanaDev/GitLocal/JavaCubes/build.gradle.kts:12:23: Unexpected tokens (use ';' to separate expressions on the same line)
e: file:///C:/Users/CanaDev/GitLocal/JavaCubes/build.gradle.kts:12:5: Unresolved reference. None of the following candidates is applicable because of receiver type mismatch:
public val NamedDomainObjectContainer<Configuration>.testImplementation: NamedDomainObjectProvider<Configuration> defined in org.gradle.kotlin.dsl

FAILURE: Build failed with an exception.

* Where:
Build file 'C:\Users\CanaDev\GitLocal\JavaCubes\build.gradle.kts' line: 12

* What went wrong:
Script compilation errors:

  Line 12:     testImplementation"junit:junit:4.13.2"
                                 ^ Unexpected tokens (use ';' to separate expressions on the same line)

  Line 12:     testImplementation"junit:junit:4.13.2"
               ^ Unresolved reference. None of the following candidates is applicable because of receiver type mismatch:
                   public val NamedDomainObjectContainer<Configuration>.testImplementation: NamedDomainObjectProvider<Configuration> defined in org.gradle.kotlin.dsl

2 errors

* Try:
> Run with --stacktrace option to get the stack trace.
> Run with --info or --debug option to get more log output.
> Run with --scan to get full insights.
> Get more help at https://help.gradle.org.

BUILD FAILED in 1s
Configuration cache entry stored.
```

Unfortunately, the block that I am led to believe that the the JUnit dependency is placed in is empty in my previous working with Gradle, and as such is not useful to me.

# Insight

I have realized that there are many options associated with creating a Gradle Project, one of which includes asking what testing framework (including Junit 4 and Jupiter)