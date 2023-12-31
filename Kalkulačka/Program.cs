﻿using System;


internal interface IOperation {
    double Execute(double a, double b);
}

public class OpAdd : IOperation {
    public double Execute(double a, double b) {
        return a + b;
    }
}

public class OpSub : IOperation {
    public double Execute(double a, double b) {
        return a - b;
    }
}

public class OpMagic : IOperation {
    public double Execute(double a, double b) {
        return a * b / 2;
    }
}


public class CalculatorContext {
    private IOperation operation;

    public CalculatorContext(IOperation operation) {
        this.operation = operation;
    }

    public double ExecuteOperation(double a, double b) {
        return operation.Execute(a, b);
    }

    public void SetOperation(IOperation operation) {
        this.operation = operation;
    }
}


class CalculatorApp {
    static void Main() {

        IOperation addOperation = new OpAdd();
        IOperation subOperation = new OpSub();
        IOperation magicOperation = new OpMagic();
        
        CalculatorContext calculator = new CalculatorContext(addOperation);

        Console.WriteLine("Zadej prvni číslo: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Zadej druhé číslo: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double result = calculator.ExecuteOperation(a, b);
        Console.WriteLine("Výsledek sčítání: " + result);

        calculator.SetOperation(subOperation);

        result = calculator.ExecuteOperation(a, b);
        Console.WriteLine("Výsledek odčítání: " + result);

        calculator.SetOperation(magicOperation);

        result = calculator.ExecuteOperation(a, b);
        Console.WriteLine("Výsledek magické operace: " + result);
    }
}
