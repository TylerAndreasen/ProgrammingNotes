# Ant

Ant is a long standing Java Build Tool, giving developers the ability to automate important, tedious, and error-prone tasks in building a Java project.
The various things that Ant can do are called Targets, come in a variety of forms, and are specified in a `build.xml` file at the root of the project.
Below can be found a sample `build.xml` file taken from [this](https://ant.apache.org/manual/tutorial-HelloWorldWithAnt.html) link, though some notes should me made about it.

1. Tasks can do one of some number of operations, but can be assigned any name as one deems fit.
2. Given the nature of the sorts of tasks that Ant is typically intended to perform, the `build.xml` will define much of the high-level structure of the project, namely defining the location of `.java` files, compiled classes, and `.jars`. These locations are then the backbone of how the project is built throughout development. Further, Targets can depend on each other. For example the `jar` target depends on the `compile` target, as there must be compiled `.class` files for a `.jar` to be created from.
3. This is provided by Apache as an example. As such, while there is no requirement to adhere completely to every small detail of the presented structure, I find information provided by the creators of tools to be best practices and helpful sign-posts of when and when not to follow the provided structure when appropriate.
4. This is not the simplest `build.xml` provided, but also does cover most of the features you may want out of Ant, notably excluding testing.
5. The tag `<property name=... value=...>` is a key-value-pair that is used like a variable throughout the rest of the build file, seemingly mostly for relative file locations.
6. If this is overwhelming, look over the first example file from the above link. This is much more limited in scope, but should be much more approachable.

```xml

<project name="HelloWorld" basedir="." default="main">

    <property name="src.dir"     value="src"/>

    <property name="build.dir"   value="build"/>
    <property name="classes.dir" value="${build.dir}/classes"/>
    <property name="jar.dir"     value="${build.dir}/jar"/>

    <property name="main-class"  value="oata.HelloWorld"/>



    <target name="clean">
        <delete dir="${build.dir}"/>
    </target>

    <target name="compile">
        <mkdir dir="${classes.dir}"/>
        <javac srcdir="${src.dir}" destdir="${classes.dir}"/>
    </target>

    <target name="jar" depends="compile">
        <mkdir dir="${jar.dir}"/>
        <jar destfile="${jar.dir}/${ant.project.name}.jar" basedir="${classes.dir}">
            <manifest>
                <attribute name="Main-Class" value="${main-class}"/>
            </manifest>
        </jar>
    </target>

    <target name="run" depends="jar">
        <java jar="${jar.dir}/${ant.project.name}.jar" fork="true"/>
    </target>

    <target name="clean-build" depends="clean,jar"/>

    <target name="main" depends="clean,run"/>

</project>

```
