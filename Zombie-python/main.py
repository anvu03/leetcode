def min_hours(grid):
    rows, cols = len(grid), len(grid[0])
    zombies = []
    humans = 0
    hours = 0

    for i in range(0, rows):
        for j in range(0, cols):
            if grid[i][j] == 1:
                zombies.append((i, j))
            else:
                humans += 1

    directions = [(0, 1), (0, -1), (1, 0), (-1, 0)]

    while len(zombies) > 0:
        new_zombies = []
        for zombie in zombies:
            for d in directions:
                neighbor = (zombie[0] + d[0], zombie[1] + d[1])
                # if within boundary
                if 0 <= neighbor[0] < rows and 0 <= neighbor[1] < cols:
                    # if this is human
                    if grid[neighbor[0]][neighbor[1]] == 0:
                        grid[neighbor[0]][neighbor[1]] = 1
                        humans -= 1
                        new_zombies.append(neighbor)
        if len(new_zombies) > 0:
            hours += 1
        zombies = new_zombies
    return hours


grid = [[0, 1, 1, 0, 1],
        [0, 1, 0, 1, 0],
        [0, 0, 0, 0, 1],
        [0, 1, 0, 0, 0]]

hours = min_hours(grid)
print(hours)
