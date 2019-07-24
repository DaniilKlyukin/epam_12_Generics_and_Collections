# Generics and Collections_12
**Task 1.**</br>
Implement a BinarySearch generic method (do not use the type constraints). Develop unit-tests.
[Решение](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/93b7d3044b3915c00c2de6e0c5db2746ea4c4da6/TasksLibrary/TasksLibrary/TasksWorker.cs#L32)
[Тесты](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/93b7d3044b3915c00c2de6e0c5db2746ea4c4da6/Tests/TaskTests.cs#L34)

</br>**Task 2.**</br>
The test file contains some information. Implement an algorithm that allows to determine the frequency of occurrences of words in the text. Develop unit-tests.
[Решение](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/93b7d3044b3915c00c2de6e0c5db2746ea4c4da6/TasksLibrary/TasksLibrary/TasksWorker.cs#L53)
[Тесты](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/93b7d3044b3915c00c2de6e0c5db2746ea4c4da6/Tests/TaskTests.cs#L45)

</br>**Task 3.**</br>
Implement a method for the counting of the Fibonacci's numbers of the Fibonacci using the iterator block yield. Develop unit-tests.
[Решение](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/93b7d3044b3915c00c2de6e0c5db2746ea4c4da6/TasksLibrary/TasksLibrary/TasksWorker.cs#L13)
[Тесты](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/93b7d3044b3915c00c2de6e0c5db2746ea4c4da6/Tests/TaskTests.cs#L21)

</br>**Task 4.**</br>
Develop a generic class-collection Queue that implements the basic operations for working with the stucture data queue. Implement the capability to iterate by collection by design pattern Iterator. Develop unit-tests.
[Решение](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/master/TasksLibrary/TasksLibrary/Queue.cs)
[Тесты](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/93b7d3044b3915c00c2de6e0c5db2746ea4c4da6/Tests/TaskTests.cs#L73)

</br>**Task 5.**</br>
Develop a generic class-collection Stack that implements the basic operations for working with the stucture data stack. Implement the capability to iterate by collection by design pattern Iterator. Develop unit-tests.
[Решение](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/master/TasksLibrary/TasksLibrary/Stack.cs)
[Тесты](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/93b7d3044b3915c00c2de6e0c5db2746ea4c4da6/Tests/TaskTests.cs#L99)

</br>**Task 6.**</br>
Develop a generic class-collection Set that implements the basic operations for working with the stucture data set with the reference types elements. Implement the capability to iterate by collection by block iterator yield. Develop unit-tests.
[Решение](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/master/TasksLibrary/TasksLibrary/Set.cs)
[Тесты](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/56f752011946b2c06e15a3415dbb0f662e7ac8aa/Tests/TaskTests.cs#L125)

</br>**Task 7.**</br>
Develop a generic class-collection BinarySearchTree that implements the basic operations for working with the stucture data binary search tree. Provide an opportunity of using a plug-in interface to implement the order relation. Implement three ways of traversing the tree: direct (preorder), transverse (inorder), reverse (postorder) (use the block iterator yield). Develop unit-tests. Use for the testiong the following types:
- System.String (use default comparison and plug-in comparator);
- the custom class Book, for objects of which the order relation is implemented (use the default comparison and plug-in comparator);
- the custom structure Point, for instance of which the relation of order is not implemented (use a plug-in comparator).
[Решение](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/tree/master/TasksLibrary/TasksLibrary/BinaryTree)
[Тесты](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/93b7d3044b3915c00c2de6e0c5db2746ea4c4da6/Tests/TaskTests.cs#L125)

</br>**Task 8.**</br>
Create a calculator which evaluates expressions in Reverse Polish notation. For example, expression 5 1 2 + 4 * + 3 - (which is equivalent to 5 + ((1 + 2) * 4) - 3 in normal notation) should evaluate to 14. Note, that for simplicity you may assume that there are always spaces between numbers and operations, e.g. 1 3 + expression is valid, but 1 3+ isn't. Empty expression should evaluate to 0. Valid operations are +, -, *, /.
[Решение](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/master/TasksLibrary/TasksLibrary/Calculator.cs)
[Тесты](https://github.com/KaBaN4iK357/epam_12_Generics_and_Collections/blob/93b7d3044b3915c00c2de6e0c5db2746ea4c4da6/Tests/TaskTests.cs#L276)
