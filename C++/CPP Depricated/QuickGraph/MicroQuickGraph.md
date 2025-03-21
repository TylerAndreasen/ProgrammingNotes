# MicroQuickGraph

The other file in this folder has a description of a somewhat simple interface based graph making tool. However, I think after reading it back, that the design is already too complicated for a version 1 for me to work on by myself. I think that for now I should build something that reads data from a file, and shows static elements on screen. Then I can learn object serialization in C++, and get the program to read and write elements to a file.
That said I will want to read up on object serialization before implementing this.

Given that, what does this need to look like for an even simpler implementation?

I will still need Vertex, Edge, and Graph classes, each of which hold onto data. It occurs to me that it may be more sensible to have a Renderer Object which is passed all of the V and E objects to draw them on screen (this will require either full getters or public fields, of which I prefer the former). At this time, the simplest case to implement is an unwieghted, undirected graph, though far into the future implementation will need to be expanded such that all graphs are wieghted and directed, while both features can be visually diabled.

vertex
    - center: vector<int,int> *
    - text: char[max=5] *
    -----
    + vertex(int _x, int _y, char* text)
    + get^^(): ^^
    + shift(int moveX, int moveY): int
    + setPos(int newX, newY): int
    + setText(char* text): int
    ? clearText(): void

edge
    - o: vertex *
    - d: vertex *
    -----
    + edge(vertex o, vertex d)
    + getOrigin(): &vertex
    + getDestination: &vertex
    + getVertices: &vector<vertex>
    + isOrigin(vertex v): boolean
    + isDestination(vertex v): boolean
    + isIncident(vertex v): boolean

Graph
    - vertices: vector<vertex> *
    - edges: vector<Edge> *
    -----
    + get^^(): &^^
    + edgeCount(): int
    + vertexCount(): int

Renderer
    - g: Graph& *
    -----
    + pushGraph(Graph&): int
    + renderAll(): int
    + renderVertices(): int
    + renderEdges(): int
    + rendervertex(int index): int
    + renderEdge(int index): int 

