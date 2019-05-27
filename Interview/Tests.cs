using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interview
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void IRepository_After_Save_Contains_Object_In_All()
        {
            var repo = new Repository<Storable>();
            var testObj = new Storable(Guid.NewGuid());
            repo.Save(testObj);
            var objects = repo.All();
            Assert.IsTrue(objects.Contains(testObj));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No object found matching this Id")]
        public void IRepository_Save_Cannot_Add_Duplicates()
        {
            var repo = new Repository<Storable>();
            var testObj = new Storable(1);
            repo.Save(testObj);
            var testObj2 = new Storable(1);
            repo.Save(testObj2);
            var objects = repo.All();
            Assert.IsTrue(objects.Count() == 1);
        }

        [TestMethod]
        public void IRepository_All_Returns_IEnum_Of_Correct_Type_And_All_Contains_Object()
        {
            var repo = new Repository<Storable>();
            var testObj = new Storable(Guid.NewGuid());
            repo.Save(testObj);
            var objects = repo.All();
            Assert.IsInstanceOfType(objects, typeof(IEnumerable<IStoreable>));
            Assert.IsTrue(objects.Contains(testObj));
        }

        [TestMethod]
        public void IRepository_FindById_Returns_Correct_Type_And_Object()
        {
            var repo = new Repository<Storable>();
            var testObj = new Storable(Guid.NewGuid());
            repo.Save(testObj);
            var testObj2 = new Storable(Guid.NewGuid());
            repo.Save(testObj2);
            var obj = repo.FindById(testObj.Id);
            Assert.IsInstanceOfType(obj, typeof(IStoreable));
            Assert.AreEqual(obj, testObj);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No object found matching this Id")]
        public void IRepository_FindById_Returns_Exception_When_Passed_Id_Not_In_List()
        {
            var repo = new Repository<Storable>();
            var testObj = new Storable(Guid.NewGuid());
            repo.Save(testObj);
            var testObj2 = new Storable(Guid.NewGuid());
            repo.Save(testObj2);
            var obj = repo.FindById(1);
            Assert.IsNull(obj);
        }

        [TestMethod]
        public void IRepository_After_Delete_All_Does_Not_Contain_Object()
        {
            var repo = new Repository<Storable>();
            var testObj = new Storable(Guid.NewGuid());
            repo.Save(testObj);
            repo.Delete(testObj.Id);
            var objects = repo.All();
            Assert.IsFalse(objects.Contains(testObj));
        }
    }
}