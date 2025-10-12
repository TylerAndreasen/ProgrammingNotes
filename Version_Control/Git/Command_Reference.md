# **Command Reference**

## **Basics**

- `git init` : Creates a git repository in the current (or possibly indicated) directory. Running this allows all* other git commands to be run, as git must have some overhead files to function. There may be options for this command, but I am yet to run into any situation that required such.

- `git status` : Prints information about the internal status of the repository. As the swiss-army knife of git commands, status tells you an enouromous amout about your repo. Importantly, it will tell you the branch you are currently on (useful if you are not using a terminal which adds this information natively), and the status of any files that have changes from the last commit (IE, new files, modified files, and deleted files). Generally speaking, until you are fluent with git, and well after said point when you are encountering issues, running git status after every functional command you run will help you soothe headaches before they start.

- `git add` : Adds a file to be commited. As files change from the version last commited, their changes will be stored and can be seen using `git status`. Once a set of changes (ideally small changes, committed often) that you are at least okay with (not perfect code) add individual files by following this command with the name of the file, or add all changed files by following the command with ` .`. This will gather all changed files to be prepared for commitment.

- `git commit` : Commits the cached changes to a repo, creating a new commit in the history of the repo (more specifically within the history of the current branch). If you are reading the reference on this command I assume you are a relative novice with git and will advise you on a couple of things.
    1. After the initial command add `-m "Text here"`, where the `Text here` is a breif message about the changes that are made within the commit (or `Initial Commit` if this is the first commit in the history of the repo). The biggest reason to do this is that you avoid potentially openning text editors unknown to you can you can't close without killing the terminal you are using. The comments themselves give you and anyone working with you an understanding of what changes were made since the previous commit, and can give team members working on other parts of a project, and in some form are required to commit changes.
    2. If you know (leaning on `git status`) that all of the changes made to the repo since the last commit should go into the next commit, you can add the flag `-a` to add all changed files within the repo to the next commit. While not an enormous time saver in one instance, it can save a lot of time over the long haul (when actually intended).

## **Caching**

- `git rm --cached path/to/file` : This removes files from being tracked by git. I sometimes find that using `*` to stop tracking all files, updating the `.gitignore`, and then re-adding all files to be simpler than removing files individually. Though if only one or two files are to be removed, individual removal may be simpler.