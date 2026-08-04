using MiniAutomationToolkit.Core.Models;
using MiniAutomationToolkit.Core.Services;

var clientOne = new Client(500, ClientType.Vip);
var clientTwo = new Client(2000, ClientType.Vip);
var clientThree = new Client(800, ClientType.Premium);
var clientFour = new Client(1000, ClientType.Premium);
var clientFive = new Client(1500, ClientType.Premium);
var clientSix = new Client(500, ClientType.Regular);
var clientSeven = new Client(1500, ClientType.Regular);
var clientEight = new Client(1000, ClientType.Regular);


DetailPrint(clientOne);
DetailPrint(clientTwo);
DetailPrint(clientThree);
DetailPrint(clientFour);
DetailPrint(clientFive);
DetailPrint(clientSix);
DetailPrint(clientSeven);
DetailPrint(clientEight);

void DetailPrint(Client client)
{
    var discount = DiscountCalculator.CalculateDiscount(client.Amount, client.Type);
    Console.WriteLine($"Client: {client.Type}, amount: {client.Amount}, discount: {discount}");
}

