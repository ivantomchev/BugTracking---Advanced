using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BugTracking.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using BugTracking.Models;
using BugTracking.Data;
using Moq;

namespace BugTracking.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexMethodShouldReturnProperNumberOfBugs()
        {
            var list = new List<Bug>();
            list.Add(new Bug());
            list.Add(new Bug());

            var bugsRepoMock = new Mock<IBugsRepository>();
            bugsRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUowData>();
            uofMock.Setup(x => x.Bugs).Returns(bugsRepoMock.Object);

            var controller = new HomeController(uofMock.Object);
            var viewResult = controller.Index();
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<Bug>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
        }
    }
}
