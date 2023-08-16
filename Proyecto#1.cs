using System;
using System.Collections.Generic;

class Menu
{
    static void Main(string[] args)
    {
        GestorClientes gestorClientes = new GestorClientes();

        while (true)
        {
            Console.WriteLine("Menú");
            Console.WriteLine("1. Agregar un cliente");
            Console.WriteLine("2. Calcular valor a pagar");
            Console.WriteLine("3. Calcular promedio de consumo");
            Console.WriteLine("4. Calcular valor total de descuentos");
            Console.WriteLine("5. Mostrar porcentajes de ahorro por estrato");
            Console.WriteLine("6. Contabilizar clientes con cobro adicional");
            Console.WriteLine("7. Salir");
            Console.WriteLine("Seleccione una opción");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    gestorClientes.AgregarClientes();
                    break;

                case 2:
                    gestorClientes.CalcularValorAPagar();
                    break;

                case 3:
                    gestorClientes.CalcularPromedioConsumo();
                    break;
                case 4:
                    gestorClientes.CalcularValorTotalDescuentos();
                    break;

                case 5:
                    gestorClientes.MostrarPorcentajesAhorroEstrato();
                    break;

                case 6:
                    gestorClientes.ContabilizarClientesCobroAdicional();
                    break;

                case 7:
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default:
                    Console.WriteLine("Opción inválida, intente de nuevo");
                    break;
            }
            Console.WriteLine("");
        }

    }
}

class Cliente
{
    public int Cedula { get; }
    public int Estrato { get; }
    public int MetaAhorro { get; }
    public int ConsumoActual { get; }

    public Cliente(int cedula, int estrato, int metaAhorro, int consumoActual)
    {
        Cedula = cedula;
        Estrato = estrato;
        MetaAhorro = metaAhorro;
        ConsumoActual = consumoActual;
    }
    
    public double CalcularValorAPAgar()
    {
        double ValorParcial = ConsumoActual * 500;
        double ValorIncentivo = (MetaAhorro - ConsumoActual) * 500;
        
        return ValorParcial - ValorIncentivo;

    }
    public double CalcularAhorro()
    {
        return Math.Max(MetaAhorro - ConsumoActual, 0);
    }    
}

class GestorClientes
{
    private Dictionary<int, Cliente> clientes;

    public GestorClientes()
    {
        clientes = new Dictionary<int, Cliente>();
    }
    public void AgregarClientes()
    {
        Console.WriteLine("Ingrese la cédula del cliente: ");
        int cedula = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el estrato del cliente: ");
        int estrato = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese la meta de ahorro del cliente (En kilovatios): ");
        int metaAhorro = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el consumo actual del cliente (En kilovatios): ");
        int consumoActual = Convert.ToInt32(Console.ReadLine());
        
        Cliente cliente = new Cliente(cedula, estrato, metaAhorro, consumoActual);
        clientes[cedula] = cliente;

        Console.WriteLine("Se agregó el cliente correctamente");
    }

    public void CalcularValorAPagar()
    {
        Console.WriteLine("Ingrese la cédula del cliente");
        int cedula = Convert.ToInt32(Console.ReadLine());

        if (clientes.TryGetValue(cedula, out Cliente cliente))
        {
            double ValorAPagar = cliente.CalcularValorAPAgar();
            Console.WriteLine($"Valor a pagar por el cliente con cédula {cliente.Cedula} es de  {ValorAPagar}");
        }
        else
        {
            Console.WriteLine("No se ha encontrado el cliente");
        }
    }

    public void CalcularPromedioConsumo()
    {
        int totalClientes = clientes.Count();
        int totalConsumo = 0;

        foreach (var cliente in clientes.Values)
        {
            totalConsumo += cliente.ConsumoActual;
        }


        double promedioConsumo = (double)totalConsumo / totalClientes;
        Console.WriteLine($"Promedio de consumo actual: {promedioConsumo} kilovatios");
    }

    public void CalcularValorTotalDescuentos()
    {
        double totalDescuentos = 0;

        foreach (var cliente in clientes.Values)
        {
            double valorIncentivo = cliente.CalcularAhorro() * 500;
            if (valorIncentivo > 0)
            {
                totalDescuentos += valorIncentivo;
            }
        }
        Console.WriteLine($"Valor total de descuentos {totalDescuentos}");
    }

    public void MostrarPorcentajesAhorroEstrato()
    {
        Dictionary<int, int> countPorEstrato = new Dictionary<int, int>();
        Dictionary<int, int> ahorroPorEstrato = new Dictionary<int, int>();

        foreach (var cliente in clientes.Values)
        {
            if (!countPorEstrato.ContainsKey(cliente.Estrato))
            {
                countPorEstrato[cliente.Estrato] = 0;
                ahorroPorEstrato[cliente.Estrato] = 0;

            }

            countPorEstrato[cliente.Estrato]++;
            ahorroPorEstrato[cliente.Estrato] += (int)cliente.CalcularAhorro();

        }
        Console.WriteLine("Porcentaje de ahorro por estrato: ");

        foreach (var estrato in countPorEstrato.Keys)
        {
            double porcentajeAhorro = (double)ahorroPorEstrato[estrato] / (countPorEstrato[estrato] * 500) * 100;
            Console.WriteLine($"Estrato {estrato}: {porcentajeAhorro}%");
        }
    }

    public void ContabilizarClientesCobroAdicional()
    {
        int clientesCobroAdicional = 0;
        foreach (var cliente in clientes.Values)
        {
            if (cliente.ConsumoActual > cliente.MetaAhorro)
            {
                clientesCobroAdicional++;
            }
            
        }
        Console.WriteLine($"Clientes con cobro adicional: {clientesCobroAdicional}");
    }
    
}