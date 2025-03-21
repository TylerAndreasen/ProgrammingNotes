# Pathfinding Pseudocode

Based on https://www.geeksforgeeks.org/shortest-path-unweighted-graph/

Breadth First Search (graph, Start, parents, distance)
    create queue vector
    assign start a distance of 0
    add starting node to queue

    while queue is not empty
        ref = queue.popfront

        (repeat for N, E, S, W)
            if neighbor is not visited
