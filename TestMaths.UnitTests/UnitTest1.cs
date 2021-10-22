using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Project2D;

namespace TestMaths.UnitTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Update_KeyboardKey()
        {
            Game u = new Game();
            u.Update();
        }
    }
}
