# PizzaBox
Pizza ordering system.

## Notes

Day 2
    - public open to all assemblies
    - protected open to assemblies in inheritance tree
    - internal open to only the assembly
    - class defaults to internal
    - method defaults to private
    - protected internal, privated protected

    - static and const created at application start (created by runtime)
    - readonly created at construction (created by us)

Day 3
    - method overloading deals with signature, method overriding deals with inheritance
    - abstract class has implementation, interface does not
    - class level variables are known as fields
    - encapsulation refers to the idea that only the internal code should handle everything including validation with its own code
    - properties are fields with their own ways of reading and writing
    - class has fields, properties, constructors, destructors

Day 4
    - Client (UI), Storing (Saving), Testing (Unit Tests, TDD) are all dependent on Domain (Logic, Object Model)
    - generic is representation of a type that will be inferred at runtime
    - factory pattern means it will create multiple objects of the same template
    - (S)ingle Responsibility, (O)pen-Closed Principle, (L)iskov's Substitution, (I)nterface Segregation, (D)ependency Inversion
        - Single responsibility refers to a structure having only one responsibility
        - Open to expansion, Closed for modification
        - Liskov's Substitutions means if it fits the format, then it should work
        - Interface Segregation 
        - Dependency Inversion
        - Boxing is value to reference, Casting is reference to reference