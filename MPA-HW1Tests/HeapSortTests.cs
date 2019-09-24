
using System;
using MPA_HW1;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MPA_HW1.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void Sort_Empty_EmptyReturned_ByName()
        {
            //arrange
            HeapSort heapSort = new HeapSort();
            List<Human> actual = new List<Human>();
            List<Human> expected = new List<Human>();

            //act
            heapSort.Sort(actual, Program.CompareByName);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_Empty_EmptyReturned_BySecondName()
        {
            //arrange
            HeapSort heapSort = new HeapSort();
            List<Human> actual = new List<Human>();
            List<Human> expected = new List<Human>();

            //act
            heapSort.Sort(actual, Program.CompareBySecondName);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_Empty_EmptyReturned_ByYearBirth()
        {
            //arrange
            HeapSort heapSort = new HeapSort();
            List<Human> actual = new List<Human>();
            List<Human> expected = new List<Human>();

            //act
            heapSort.Sort(actual, Program.CompareByYearBirth);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_HumansList_SortedHumansList_ByName()
        {
            //arrange
            HeapSort heapSort = new HeapSort();
            List<Human> expected = new List<Human>()
            {
                new Human("Alesha", "Popov", 2003),
                new Human("Amin", "Avarin", 2000),
                new Human("Igor", "Baranov", 1990),
                new Human("Ivan", "Kuleshov", 2010),
                new Human("Ivan", "Ivanov", 2000),
                new Human("Petr", "Kuleshov", 1999),
                new Human("Vlad", "Klemenko", 2001),
                new Human("Yan", "Koght", 1998),

            };

            //act
            List<Human> actual = new List<Human>()
            {
                new Human("Ivan", "Ivanov", 2000),
                new Human("Ivan", "Kuleshov", 2010),
                new Human("Petr", "Kuleshov", 1999),
                new Human("Igor", "Baranov", 1990),
                new Human("Yan", "Koght", 1998),
                new Human("Alesha", "Popov", 2003),
                new Human("Amin", "Avarin", 2000),
                new Human("Vlad", "Klemenko", 2001),
            };
            heapSort.Sort(actual, Program.CompareByName);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_HumansList_SortedHumansList_BySecondName()
        {
            //arrange
            HeapSort heapSort = new HeapSort();
            List<Human> expected = new List<Human>()
            {
                new Human("Amin", "Avarin", 2000),
                new Human("Igor", "Baranov", 1990),
                new Human("Ivan", "Ivanov", 2000),
                new Human("Vlad", "Klemenko", 2001),
                new Human("Yan", "Koght", 1998),
                new Human("Petr", "Kuleshov", 1999),
                new Human("Ivan", "Kuleshov", 2010),
                new Human("Alesha", "Popov", 2003),
            };

            //act
            List<Human> actual = new List<Human>()
            {
                new Human("Alesha", "Popov", 2003),
                new Human("Amin", "Avarin", 2000),
                new Human("Igor", "Baranov", 1990),
                new Human("Ivan", "Kuleshov", 2010),
                new Human("Ivan", "Ivanov", 2000),
                new Human("Petr", "Kuleshov", 1999),
                new Human("Vlad", "Klemenko", 2001),
                new Human("Yan", "Koght", 1998),
            };
            heapSort.Sort(actual, Program.CompareBySecondName);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_HumansList_SortedHumansList_ByYearBirth()
        {
            //arrange
            HeapSort heapSort = new HeapSort();
            List<Human> expected = new List<Human>()
            {
                new Human("Igor", "Baranov", 1990),
                new Human("Yan", "Koght", 1998),
                new Human("Petr", "Kuleshov", 1999),
                new Human("Ivan", "Ivanov", 2000),
                new Human("Amin", "Avarin", 2000),
                new Human("Vlad", "Klemenko", 2001),
                new Human("Alesha", "Popov", 2003),
                new Human("Ivan", "Kuleshov", 2010),
            };

            //act
            List<Human> actual = new List<Human>()
            {
                new Human("Alesha", "Popov", 2003),
                new Human("Amin", "Avarin", 2000),
                new Human("Igor", "Baranov", 1990),
                new Human("Ivan", "Kuleshov", 2010),
                new Human("Ivan", "Ivanov", 2000),
                new Human("Petr", "Kuleshov", 1999),
                new Human("Vlad", "Klemenko", 2001),
                new Human("Yan", "Koght", 1998),
            };
            heapSort.Sort(actual, Program.CompareByYearBirth);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
