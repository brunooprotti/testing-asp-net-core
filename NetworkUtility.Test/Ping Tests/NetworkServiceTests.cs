using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;

namespace NetworkUtility.Test.Ping_Tests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _service;
        private readonly IDNS _dns;

        public NetworkServiceTests()
        {
            //Dependencies   
            _dns = A.Fake<IDNS>(); //Hacemos un call fake a la IDNS para no ejecutar ninguna accion dentro de la base de datos


            _service = new NetworkService(_dns);
        }

        [Fact] //Esto es lo que hace que lo mire como un test es como el it en angular.
        public void NetworkService_SendPing_ReturnString()
        {
            /***
                 Si lo pensamos como un ejemplo la regla de las 3 a es por ejemplo la accion de cargar el celular:
                 Arrange - vamos a buscar el cargador.
                 Act     - Enchufamos el cargador.
                 Assert  - Tenemos el celular cargado.

             */

            //Arranges - Get or declare all variables, classes or mocks, etc.
            //var pingService = new NetworkService();

            A.CallTo(()=> _dns.SendDNS()).Returns(true); //en el codigo la linea de la llamada a la interfaz se omite y se retorna directamente un true.

            //Act - Execute the function to test
            var result = _service.SendPing();

            //Asserts  - son como el expect en angular, las Fluent assertions tienen mejores exceptions o mensajes de error para los test.
            result.Should().NotBeNullOrWhiteSpace().And
                  .Be("Success: Ping sent!").And
                  .Contain("Success",Exactly.Once());
        }


        [Theory] //Se usa para metodos que necesitan uno o varios parametros.
        [InlineData(1,1,2)]
        //[InlineData(1,1,2)] Podemos tener uno o mas casos de prueba. Los parametros son 1 y 1, el 2 nos indica lo que nos va a devolver.
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange
            //var pingService = new NetworkService();

            //Act
            var result = _service.PingTimeOut(a,b);

            //Assert
            result.Should().Be(expected);

        }

        [Fact] 
        public void NetworkService_LastPingDate_ReturnDate()
        {
            //Arranges - Get or declare all variables, classes or mocks, etc.
            
            //Act - Execute the function to test
            var result = _service.LastPingDate();

            //Asserts  - son como el expect en angular, las Fluent assertions tienen mejores exceptions o mensajes de error para los test.
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }
        [Fact] 
        public void NetworkService_GetPingOptions_ReturnObject()
        {
            //Arranges - Get or declare all variables, classes or mocks, etc.
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            };
            
            //Act - Execute the function to test
            var result = _service.GetPingOptions();

            //Asserts  - son como el expect en angular, las Fluent assertions tienen mejores exceptions o mensajes de error para los test.
            
            //Cuidado cuando usamos "Be()" porque hace una comparacion estricta contra lo que contiene dentro.
            //Es mejor hacer un mock y comparar el tipo y que sea equivalente a ese mock
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
        }
        
        [Fact] 
        public void NetworkService_MostRecentPings_ReturnObject()
        {
            //Arranges - Get or declare all variables, classes or mocks, etc.
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            };
            
            //Act - Execute the function to test
            var result = _service.MostRecentPings();

            //Asserts  - son como el expect en angular, las Fluent assertions tienen mejores exceptions o mensajes de error para los test.
            
            //Cuidado cuando usamos "Be()" porque hace una comparacion estricta contra lo que contiene dentro.
            //Es mejor hacer un mock y comparar el tipo y que sea equivalente a ese mock
            result.Should().BeOfType<IList<PingOptions>>();
            result.Should().ContainEquivalentOf(expected); //Este es lo mismo que el BeEquivalentTo si no que compara contra una lista.
            result.Should().Contain(x => x.DontFragment == true);
        }


    }
}
