using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Test
{
    public static class WorldDumbestFunctionTest
    {
        //Naming convention - ClassName_MethodName_ExpectedResult
        public static void WorldDumbestFunction_ReturnPikachuIfZero_ReturnsPikachu()
        {
            try
            {
                //Triple AAA Rule.

                //Arrange - Go get your variables, classes, functions or whatever you need

                int num = 0;
                WorldDumbestFunction worldDumbest = new WorldDumbestFunction();

                //Act - Execute this function 
                string result = worldDumbest.ReturnsPikachuIfZero(num);

                //Assert - Whatever ever is returned is it what you want. 


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
