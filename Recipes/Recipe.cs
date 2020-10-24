//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID
{
    public class Recipe
    {   
        //Es una invariable que exista ena lista steps porque es necesaria para todos los metodos
        
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            // Precondicion que exista steps 

            //Operacion
            this.steps.Add(step);

            // Poscondicion
            if(!steps.Contains(step))
            {
                throw new Exception("step no esta en la lista");
            }
        }

        public void RemoveStep(Step step)
        {
            // Precondicion:
            if(!steps.Contains(step))
            {
                throw new Exception("step no esta en la lista");
            }

            // Operacion:
            this.steps.Remove(step);

            // Poscondicion:
            if(steps.Contains(step))
            {
                throw new Exception("step sigue estando");
            }

        }

        public void PrintRecipe()
        {
            //Precondicion 
            if (this.FinalProduct.Description==null)
            {
                throw new Exception("FinalProduct no esta definido");
            }
            foreach (Step step in steps)
            {
                if (step.Quantity==0 && step.Input.Description==null && step.Equipment.Description== null && step.Time== 0)
                {
                    throw new Exception("step dentro de steps no esta bien definido");
                }
            }

            //Operacion
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }

            //Postcondicion
            //Se lleva a cabo la operacion imprimiendo por consola el mensaje
        }
    }
}
