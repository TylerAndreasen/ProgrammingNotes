# G/RE/P

Backronyms, history, and references aside, `grep` is a command line tool built to parse and apply regular expressions, or regexes.

The basics of the command and regexs are pretty straight forwards. But regexs especially can become monstrously complicated, though equally powerful.

Recently I wanted to get a copy of all of the method definition lines in a python file, and after briefly forgetting the difference between `awk` and `grep`, came up with this command.

```grep
$ grep def test/test_naming_convention.py
    def test_variable_pass(self):
    def test_constant_variable_pass(self):
    def test_class_pass(self):
    def test_function_pass(self):
    def test_variable_fail_mixed_caps(self):
    def test_constant_variable_fail_mixed_caps(self):
    def test_function_fail_mixed_caps(self):
    def test_class_fail_underscores(self):
    def test_class_fail_no_caps(self):
    def external_start(self):

```

This use case is one of the simplest for a `grep` command. The command looks for any line containing the token `def` and prints the entire line. In this case, what I really want is just the method names, which means that awk, or outside parsing is required.
Ultimately I choose to use the VS Code instance that I already had open and filter out the sections of each line I needed. While grep may not be a tool I see myself using everyday, it is one tool in the tool box, only made more powerful by the `|` pipeline indicator and `awk`.