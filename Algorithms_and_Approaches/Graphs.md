# Graphs

Formally, a Graph is defined as a tuple containing a Vertex set and an Edge set, where the Edge set is a subset of the Set Product of the Vertex set X the Vertex set.
You can use graph theory and it's derived algorithms to solve many complicated problems when the data you are operating on looks like a collection of interconnected data, but the algorithm and representation in memory you choose should be informed by the nature of the implied graph structure and the sort of analysis that you are looking to do.

Often, you are trying to determine the existance of a connection or the minimum distance between two vertices in the graph, though not always.

## Variants of Shortest Path

1) `s-t` Shortest Path: determine the shortest path between two nodes `s` and `t`, and the distance between them.
2) `SSSP` or Single Source Shortest Path: Determining the shortest path to all vertices in a graph from a single source vertex.
3) `APSP` or All Pairs \` \`: TODO Research this

## Memory Representations

1. Adjascency matrix: A binary matrix within which a point `(i,j)` storing the value `1` represents a connection from `i` to `j`, and a `0` represents no connection. Directed graphs enforce either the first or second index of the matrix as the outgoing edge. Very space inefficient for sparesly connected graphs. Weighted graphs can be implemented by assigning numeric values instead of binary values to positions in the matrix.

2. Adjascency List: A list (which is indexed by the respective vertex) of lists which store the adjascent vertices. Faster time complexity can be achieved for directed graphs by storing a list of ingoing and outgoing edges.

2. 1. Implementing an adjascency list as nested hashmap can speed up accesses to constant time

## Search Algorithms

### 1. Depth-First Search:
 -1 Select an unexplored element, push it to the stack
 -2 if the top element of the stack has no unexplored edges
    -2-1 Pop the stack
 -3 else
    -3-1 Select an unexplored edge, put the other vertex on said edge on top of the stack
 -4 If no unexplored elements remain, return

This behavior can be achieved in a more useful manner by coloring vertices white at the start, grey when they are first discovered, and black when all (out going) edges are explored. When a vertex is discovered and when it is blackend, timestamps are made which helps give additional context about the structure of the graph.

The DFS can be used to create one or more depth-first trees (depending on the connectedness and structure of the graph), which also give context about the strucutre of the graph. Vertices can be cut off from the initial processing loop by visiting neighboring vertices in particular ways.

:Tree Edges - a subset of V which contains those edges `(u,v)` for which vertex `v` was first discovered by exploring edge `(u,v)` within a depth first tree.
:Back and Forward Edges - Edges (u,v) which connect vertex `u` to an ancestor or descendant vertex `v` within a depth first tree.
:Cross edges - those edges which do not belong to the Tree Edges set, Back Edges set, or Forward Edges set.

### 2. Topological Sort

Given a DAG, it is possible to give a `topological order` to vertices of the DAG using DFS. When a value `v.f` is assigned, add `v` to the front of a linked list. When all vertices are visited, return the list for a reverse topological sort, though many valid topological orders can exist for a given DAG. This has means that for any two vertices `u` and `v` if the timestamps associated with `u` are bounded by those associated with `v`, then u is a decendant of v.

### 3. Kahn's Algorithm

For DAG's,

0. Define a visited node count variable initialized to 0
1. Create an array to store the in-degrees of all nodes, and a result array.
2. Populate the in-degree array.
3. Create a queue and push all 0-in-degree elements of the array into the queue
3. 1. If the queue is empty at this point, this cannot be a DAG (if detecting DAGs).
4. Pop a node v from the queue and add it to the result array.
4. 1. For each node that v points to, decrease the in degree
4. 2. if an in degree is reduced to 0, move the vertex into the queue.
5. Repeat from Step 3 until queue is empty
6. If the visited node count is not equal to the total number of nodes, there must be a cycle, and is not a DAG (and by extention no Topological Order can be created).

### 4. Dijkstra's Algorithm
SSSP
Assumes non-negative cycle, implements an estimated distance for every vertex, which is guarenteed to be correct when the algorithm finishes.

```
Overview

Define a list of distances for each node, each initialized to +inf
F con
```


### 5. Bellman-Ford
SSSP, Allows negative edge wieghts. Covered in detail in Slides 10, relies on Dynamic Programming.

### 6. Breadth First Search

For Single Source, Shortest Path in unweighted.
For a given graph with one source (IE starting point), calculate the shortest path from the source to all of the nodes in the graph. All nodes which are directly connected to the source, the first fronteir.
Subsequent distances are those nodes not yet visited and are immadiately adjascent to elements from the previous frontier.
Implements the idea of layers in the graph, where L_0 is just source, and L_n is the set of vertices with a distance of n from the source.
Easy to implement iteratively with a queue and a structure to mark vertices as visited

Psuedo:
```
//Array
BFS(Node& s)
{
   <int,int> predecesor_table
   visited = {false * v}
   vec<vec<int/Node>> L {}
   L[0] = s
   for i in range n-1 // n is node count
      if L[i] is empty
         retutn
      while L[i] not empty
         u = L[i].pop
         for each x = u.neighbor
            if not visited[x]
               visited[x] = true
               L[i+1].pushback(x)
               pred.append({x,u})

}


//Queue
// I have found this to be more practical in c++ than the prior
BFS(G, s)
   vec<bool> explored
   vec<int> distances
   for v in G
      explored.push_back(false)
      distances.push_back(+inf)

   explored[0] = true
   distances[0] 0
   queue q = (g[0] or s)
   while q not empty
      u q.pop
      for v in u.neighbors
         if not explored[v]
            explored[v] = true
            distance[v] = d[u] + (1 or weight)
            q.push_back(v)
```

### 7. Floyd_Warshall Algorithm
APSP (For All u,v from Vertices, d(u,v), often faster to implement this over running SSSP for evrey vertex)

d_k[v] := Shortest Distance from (fixed) s to v with at most k edges. 0 <= k <= n-1

d_k[v] =
{
   min
   (
      min(d_(k-1)[x] + w(x,v) x \belongsto V)
   )
}

Alternate formulation

APSP,
d_k(u,v) := the shortest length from u to v that uses intermediate vertices only from {1,...,k} := d_n(u,v)

For all 0<=k <= n

d_0(u,v) = 0 if u == v, +inf otherwise

d_0(u,v) = w(u,v) if u and v are connected, +inf otherwise

d_1(u,v) =

d_k(u,v) =
{
   min
   (
      d_(k-1)(u,k)+d_k-1(k,v),
      d_(k-1)(u,v)
   )
}
