# Game of Life
An implementation of Conway's Game of Life in Unity engine, using cube mesh renderers.

By default, uses standard ruleset for the original Game of Life by John Conway (notated B3/S23). The user may also enter their own rulesets as well, or use one of many presets. Also capable of cellular automata simulations in three and four dimensions.

### Controls
Right-click and drag to rotate board.
Middle-click and drag to move board.
Alt+Z to toggle the UI on/off.

### Limitations
* Currently there is no way to rewind the state of the board.
* Rendering is by far the biggest performance issue. The algorithm itself runs fast enough on modern hardware, but Unity's renderer doesn't play well with millions of cubes on the screen.
* There is no way to treat certain neighbors differently, for example by counting orthogonal neighbors differently from diagonal neighbors.

### Credits
* https://conwaylife.com/ and its associated [wiki](https://conwaylife.com/wiki/). General information and interesting reading.
* [Bays, Carter - Candidates for the Game of Life in Three Dimensions (1987)](https://content.wolfram.com/sites/13/2018/02/01-3-1.pdf). Early exploration of some concepts for 3D Life and basic rulesets.
* [Bays, Carter - A Note About the Discovery of Many New Rules for the Game of Three-Dimensional Life (2006)](https://content.wolfram.com/sites/13/2023/02/16-4-7.pdf). Additional explorations of 3D Life and interesting rulesets, and designs for gliders in different 3D rulesets.
* [Wallace, Evan - Conway's Game of Life in 3D](https://cs.brown.edu/courses/cs195v/projects/life/edwallac/index.html). Brief exploration of 3D Life and one of my favorite rulesets, I call "Wallace 2". Inspiration for a similar 4D ruleset.
* [Evans, Chris - Building Conway's Game of Life in 3D (2020)](https://chrisevans9629.github.io/blog/2020/07/27/game-of-life). Another ruleset.
* 
