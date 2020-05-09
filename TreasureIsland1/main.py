from pprint import pprint
from queue import Queue


def min_step(grid):
    ROW, COL = len(grid), len(grid[0])
    directions = [[0, 1], [0, -1], [1, 0], [-1, 0]]
    marks = [[0 for col in range(len(grid[0]))]
             for row in range(len(grid))]

    print(marks)

    treasure_islands = []
    for i in range(ROW):
        for j in range(COL):
            if grid[i][j] == 'X':
                treasure_islands.append([i, j])

    def bfs(grid, step_taken, start):
        queue = Queue()
        queue.put(start)

        while not queue.empty():
            row, col = queue.get()
            for d in directions:
                i, j = row + d[0], col + d[1]
                if 0 <= i < ROW and 0 <= j < COL:
                    if grid[i][j] != 'D' and marks[i][j] == 0 and (i, j) != start:
                        queue.put((i, j))
                        marks[i][j] = marks[row][col] + 1

    bfs(grid, 0, (0, 0))

    for island in treasure_islands:
        print(marks[island[0]][island[1]])

    for i in marks:
        print(i)


grid = [
    ['O', 'O', 'O', 'O'],
    ['D', 'O', 'D', 'O'],
    ['O', 'O', 'O', 'O'],
    ['X', 'D', 'D', 'O']
]

min_step = min_step(grid)

print(min_step)
