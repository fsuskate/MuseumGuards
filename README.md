# MuseumGuards

Museum Guards

You are in charge of security for a museum that is a grid of M x N rooms. Rooms can be empty, occupied by a guard, or locked.

* Guards can move in any of four directions:  up, down, right, left
* Guards cannot move into a locked room, or off the grid.
* Guards can only move into an adjacent room (at most four).
* Guards can only move one step at a time to an adjacent room.

You are given M, N, and the initial positions of each guard on the museum's grid.

Your objective is to assign a value to each room indicating how quickly any guard can get to that room. An empty room adjacent to a guard has a value of 1 since that guard can get to it as quickly as any other guard (in one step).

Please solve this problem, write the code, and provide an analysis of the time complexity of your solution.

Example:

Given this example grid (G = guard, L = locked cell),

_________________
| G |   |   |   |
_________________
|   | L | L |   |
_________________
|   | L |   |   |
_________________
|   |   | G |   |
_________________
|   |   |   |   |
_________________

The output should be something like this (could be a data structure with these values, U = undefined):

_________________
| 0 | 1 | 2 | 3 |
_________________
| 1 | U | U | 3 |
_________________
| 2 | U | 1 | 2 |
_________________
| 2 | 1 | 0 | 1 |
_________________
| 3 | 2 | 1 | 2 |
_________________