﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppVentas.Models;
using SQLite;

namespace AppVentas.ViewModels
{
    public class VentasViewModel
    {
        private SQLiteConnection conec;
        private static VentasViewModel instance;
        public static VentasViewModel Instance {
            get {
                if (instance == null) { throw new Exception("Falta inicializar"); }
                return instance;
            }
        }

        public static void Inicializador(String filename)
        {
            if (filename == null) { throw new ArgumentException(); }
            if (instance != null) { instance.conec.Close();}
            instance = new VentasViewModel(filename);
        }

        private VentasViewModel(String DbPath)
        {
            conec = new SQLiteConnection(DbPath);
            conec.CreateTable<Ventas>();
        }
        public String EstadoMensaje;

        public int AddNewVenta(string producto, int cantidad, DateTime fecha)
        {
            int result = 0;

            try
            {
                result = conec.Insert(new Ventas()
                {
                    Producto = producto,
                    Cantidad = cantidad,
                    Fecha = fecha
                });
                EstadoMensaje = string.Format("Ingresado correctamente");
            }
            catch(Exception e)
            {
                EstadoMensaje = e.Message;
            }

            return result;
        }

        public IEnumerable<Ventas> GetAllVentas()
        {
            try
            {
                return conec.Table<Ventas>();
            }
            catch(Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Ventas>();
        }
    }
}
