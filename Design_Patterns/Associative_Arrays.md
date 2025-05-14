# Associative Arrays

The concept of an Associative Arrays is one I have come across but not heard in relation to the term itself.
Java and JS call them HashTables, where Python calls them Dictionaries.
Ultimately they create Key-Value-Pair Associations, which is where the name comes from.
You create pairs of values that can be used to identify the latter of the pair.
But unlike a standard array, the index value can be anything: text, real numbers, et cetera.
Generally this is done by applying some hash to the key, finding a location in a normal array, and following the contained pointer to the location of the value (which may have a stored copy of the key alongside). In the case of a collision, a linked list of elements is created.