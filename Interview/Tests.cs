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
        [ExpectedException(typeof(NullReferenceException))]
        public void IRepository_Save_Returns_Success_And_Contains_Object_In_All()
        {
            var repo = new Repository<Storable>();
            var testObj = new Storable(1);
            bool success = repo.Save(testObj);
            var objects = repo.All();
            Assert.IsTrue(success);
            Assert.IsTrue(objects.Contains(testObj));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void IRepository_All_Returns_IEnum_Of_Correct_Type()
        {
            var repo = new Repository<Storable>();
            var testObj = new Storable(1);
            bool created = repo.Save(testObj);
            var objects = repo.All();
            Assert.IsInstanceOfType(objects, typeof(IEnumerable<IStoreable>));
            Assert.IsTrue(objects.Contains(testObj));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void IRepository_FindById_Returns_Correct_Type()
        {
            var repo = new Repository<Storable>();
            var testObj = new Storable(1);
            bool created = repo.Save(testObj);
            var obj = repo.FindById(testObj.Id);
            Assert.IsInstanceOfType(obj, typeof(IStoreable));
        }



        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void IRepository_Delete_Returns_Bool_Or_Null_Ref_Exception()
        {
            var repo = new Repository<Storable>();
            var testObj = new Storable(1);
            bool created = repo.Save(testObj);
            var objects = repo.All();
            bool success = repo.Delete(testObj.Id);
            Assert.IsTrue(success);
            Assert.IsFalse(objects.Contains(testObj));
        }
    }
}