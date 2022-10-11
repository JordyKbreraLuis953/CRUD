using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4toTI.Models;

namespace _4toTI.Services;

    public class BebidasService
    {
    static List <Bebidas> Bebidas {get;}

    static int nextId = 3;

    static BebidasService ()
    {
    Bebidas = new List <Bebidas> {
        new Bebidas {Id = 1, Name = "Aguas Naturales", Na = false},
        new Bebidas {Id = 2, Name = "Mirinda", Na = false},
     };
    }
    public static List <Bebidas> GetAll()=> Bebidas;

    public static Bebidas Get (int Id)=> Bebidas.FirstOrDefault (p => p.Id == Id);

    public static void Add(Bebidas bebidas)
    {
       bebidas.Id = nextId++;
    Bebidas.Add(bebidas);
    }
    public static void Delete(int Id)
    {
       var bebidas = Get(Id);
       if(bebidas is null)
       return;

        Bebidas.Remove(bebidas);
    }
    public static void Update(Bebidas bebidas)
    {
        var index = Bebidas.FindIndex(p => p.Id == bebidas.Id);
        if(index == -1)
        return;

         Bebidas[index] = bebidas;
    }
    }
