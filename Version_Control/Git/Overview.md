# **GO ON, GIT**

Despite using `git` some for years and extensively for about a year now, I am yet to add notes on `git` to this repo.
It is high time I change this, though I should note that I will be discussing both the CLI `git` and the data storage provider GitHub. And no, I do not use GitHub Desktop.

## **Overview**

`git` is a type of Version Control software. This means that a user can submit files to a `git` repository, make changes, save snapshots of those changes, rollback to previous snapshots, and much more. Often, Version Control software is used to manage codebases (software projects that take up multiple files, often spread across many folders for organizational purposes).

GitHub is an online data storage platform that is closely integrated with the `git` CLI, though is not the only method by which `git` can send data remotely. 

## **Workflow (simple)**

Software development workflows that include `git` and GitHub have three places data are stored and several steps to move data around. The first place is called `local`, which is typically the physical device a developer is using to run `git`.

To keep things simple lets create an example where Alice and Bob are working together on a software project.
To start the project off, Alice opens a terminal and a code editor (possibly creating a "project"/equivalent in the editor). Once the place where code files are going to be stored is defined, Alice runs the command `git init` to create the background files to define a `git` repo (I have never had to interact directly with these files, and I imagine I won't need to for a long time yet). (Note: For code editors that nest the user's code within extra folders, it is generally better to create the repo at the shared parent folder of all code files written by the user to minimize unnecesary tracking of device or editor specific files.)

Next, Alice defines a `.gitignore` file. (Note: Unless otherwise specified, Operating Systems typically hide files and folders that have names beginning with a `.` as these are often critical to operation, and unwitting modification or deletion of these files can cause problems.) By using regular expressions, Alice is able to define folders and files that `git` will not add to the list of what it is tracking (Note: Files already tracked by `git` will not be dropped from tracking if the `.gitignore` is modified to include that file, see **Common Issues**). Often this file specifies files that are specific to the device or the editor (no need for Alice to force editor-and-project-specific settings on Bob by including those files in their repo), large files which cannot be managed easily (See **Limitations of `git`**), and log or scratch files (respectively, files that store records of program behavior or output, and files used by developers in debugging or for text manipulation purposes).

Third, Alice will create some basic files for the repo to manage. These don't necessarily need to be substantive, just something to share with Bob.

Next, Alice will create a `README` file. For projects larger than 1-2 files, development can be much smoother if a document is provided with the purpose of explaining the high-level purpose of the repo as a whole, and `README` is the traditional title given to these files, and will be the default file shown on GitHub when viewed on GitHub (we will get there soon).

Having wrapped up her initial file set up, Alice can open up her terminal again. Out of prudence, Alice's first command (after ensuring the terminal is pointing to where her local copy of the repo is) should be `git status`. This will return a report of the state that her local repo is in. Given the above description, the command will return that some number of files, including the `README` have been created but not yet tracked. At this time, if Alice notices that files/folders which do not need to be tracked are still present, she can modify the `.gitignore` file, rerun the command and said files/folders should not be present (assuming the regexes are correct). 

Once the files are correct, Alice will run `git add`, which will add single files (if a file name is specified), or any file that matches a regex supplied at the end of the command. Tip: a single `.` will add all files, respecting the `.gitignore`. This adds all files not being tracked by `git` to said list.

For her last local step, Alice will "commit" her work by running `git commit`. Note: depending on the terminal and other factors, running those two tokens as a command will open a text editor, as by default commits to a git repo should have a message associated with them. I have made it a habit to extend the `git commit` command with `-m ""`, where the double quotes surround a message about what changes are made within the commit.

With her local work completed, Alice runs a command that looks something like the following:
`git push --set-upstream https://github.com/Alice/SuperFunProject main`
(See **Workflow (branches)** for information on the token `main`.)
This command can likely be split into multiple, but is simple enough on its own.

We have discussed Alice's local repo, files that exist on her hardware. But only having her files on her hardware is asking to loose those files, so it is prudent for her to keep a remote copy of those files. `git` allows files to be sent to a remote device running a git server program (in this case GitHub, though there are plenty of options depending on the needs of the project). The `push` token imples that Alice wants to notify the `remote` version of the repo that changes have been made, the second type of place `git` repos are stored. Assuming the supplied link is reachable, defined to be a repo, and proper permissions are present on the device (this is not the sort of document to explain this), the `remote` copy of the repo will have the changes that Alice has made added to itself (Note: All changes that Alice pushes are present on remote, especially as branches (see below) are introduced, not all changes to `remote` will necessarily be reflected on `local`).

Now that Alice's files are online and ready to be shared, Bob can act. Once given a link, Bob can move his terminal to where he would like to store the repo. He runs `git init` to define a repo and make other commands meaningful. Bob then runs `git pull --set-upstream https://github.com/Alice/SuperFunProject main`, this copies not only all of the files that Alice submitted into `git`, but any commit history that Alice may have created since the inital commit, allowing him to move through the version history, just as Alice can (as she would have created any changes). When Bob has made any changes he sees fit, he runs `git add` specifying the files changed as needed, then `git commit` and adding some message in an editor or through a command option. Finally, he updates `remote` with his changes using `git push`, as the upstream was already set.

Going forwards, before Alice or Bob being working on the project, they are advised to run `git pull` or `git fetch` (minimal differences for a first time user) to copy any changes made down to their `local`. Then when they are done with a unit of work, `git add` necessary files, `git commit` with a message, and `git push` to reflect their local changes remotely.

As described below, there are two major complications that have not been discussed: Branches and Upstream. See **Workflow (branches and upstream)**.

## **Workflow (branches and upstream)**
## **Command Reference**
## **Common Issues**
## **Limitations of `git`**