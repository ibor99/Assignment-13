# Assignment-13

Code smells:
- it was involved with internals of other classes, violating encapsulation
- The Register method was quite long and contained a lot of successive and nested conditionals, it was hard to read.
- a lot of primitives in the class

SOLID / Clean Code principles violations:

-Single Responsability Principle , because it was doing too much in the Register method.

-DRY , due to repetead logic use.(dont repeat yourself)

Refactoring done:

- extracted into smaller methods
- exceptions are more descriptive
- encapsulated data like setting some things privately
- repeated logic put into separate methods
