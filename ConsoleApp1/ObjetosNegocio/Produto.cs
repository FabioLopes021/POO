﻿/*
*	<copyright file="ClassLibrary1.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/11/2023</date>
*	<description></description>
*/

using Dados;
using System;
using System.Collections.Generic;

namespace ObjetosNegocio
{
    [Serializable]
    /// <summary>
    /// Purpose: Garantia de classe 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/11/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Produto: IProduto
    {
        #region Attributes

        static int totProd;
        int id;
        string nome;
        float valor;
        float garantiaAnos;
        int catgId;
        int marcaId;
        float quantidade;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Constutor estatico
        /// </summary>
        static Produto()
        {
            totProd = 1;
        }

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Produto()
        {
            nome = "";
            valor = 0;
            garantiaAnos = 0;
            id = totProd;
            totProd++;
            catgId = 0;
            marcaId = 0;
            quantidade = 0;
        }

        /// <summary>
        /// Construtor com dados
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="valor"></param>
        /// <param name="garantia"></param>
        /// <param name="catgId"></param>
        /// <param name="marcaId"></param>
        public Produto(string nome, float valor, float garantia, int catgId, int marcaId)
        {
            this.nome = nome;
            this.valor = valor;
            this.garantiaAnos = garantia;
            this.catgId = catgId;
            this.marcaId = marcaId;
            this.id = totProd;
            this.quantidade = 0;
            totProd++;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para aceder a variavel id
        /// </summary>
        public int Id{
            set{ id = value; }
            get{ return id;  }
        }

        /// <summary>
        /// Propriedade para aceder a variavel nome
        /// </summary>
        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        /// <summary>
        /// Propriedade para aceder a variavel valor
        /// </summary>
        public float Valor
        {
            set { valor = value; }
            get { return valor; }
        }

        /// <summary>
        /// Propriedade para aceder a variavel garantiaAnos
        /// </summary>
        public float GarantiaAnos
        {
            set { garantiaAnos = value; }
            get { return garantiaAnos;}
        }

        /// <summary>
        /// Propriedade para aceder a variavel catgId
        /// </summary>
        public int CatgId
        {
            set { catgId = value; }
            get { return catgId; }
        }

        /// <summary>
        /// Propriedade para aceder a variavel marcaId
        /// </summary>
        public int MarcaId
        {
            set { marcaId = value; }
            get { return marcaId; }
        }


        /// <summary>
        /// Propriedade para aceder a variavel quantidade
        /// </summary>
        public float Quantidade
        {
            set { quantidade = value; }
            get { return quantidade; }
        }

        /// <summary>
        /// Propriedade para aceder a variavel estatica totProd
        /// </summary>
        public static int TotProd
        {
            set { totProd = value; }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Operador que verifica se dois objetos desta classe sao iguais
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Produto p1, Produto p2)
        {

            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
                return false;

            if (p1.Id == p2.Id)
                return true;

            return false;
        }


        /// <summary>
        /// Operador que verifica se dois objetos desta classe sao diferentes
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Produto p1, Produto p2)
        {
            if (p1 == p2)
                return false;

            return true;
        }


        #endregion

        #region Overrides


        /// <summary>
        /// Metodo que verifica se dois objetos desta classe sao iguais
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Produto)
            {
                Produto a = obj as Produto;

                if ((a.Id == this.Id))
                {
                    return true;
                }
            }

            return false;
        }



        /// <summary>
        /// Implementaçao do Metodo ToString() para esta classe
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Id: {0}, Nome: {1},Valor: {2}, Garantia: {3}, CategoriaId: {4}, MarcaId: {5}, Quantidade: {6}",this.Id,this.Nome,this.Valor,this.GarantiaAnos,this.CatgId,this.MarcaId, this.Quantidade);
        }

        #endregion

        #region Other_Methods

        /// <summary>
        /// Metodo para calcular id a ser atribuido a cada Produto a ser criado
        /// </summary>
        /// <returns></returns>
        public static int AtribuirId()
        {
            int maxid = 1;

            List<Produto> lista = Stock.ListaProdutos;

            if (ReferenceEquals(lista, null) || lista.Count == 0)
                return maxid;

            foreach (Produto aux in lista)
            {
                if (aux.id > maxid)
                    maxid = aux.id;
            }

            return ++maxid;
        }


        /// <summary>
        /// Metodo para verificar se o produto esta completo com os dados obrigatorios
        /// </summary>
        /// <returns></returns>
        public bool VerificaIntegridadeProduto()
        {
            if((this.nome == "") || (this.valor <= 0) || (this.garantiaAnos < 0))
                return false;

            if (!Marcas.VerificaMarcaPorId(this.MarcaId) || !Categorias.VerificaCategoriaPorId(this.CatgId))
                return false;
            
            return true;
        }


        /// <summary>
        /// Metodo para alterar o nome de um produto
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool AlterarNome(string nome)
        {
            if (ReferenceEquals(this, null) || nome == "")
                return false;

            this.Nome = nome;

            return true;
        }


        /// <summary>
        /// Metodo para alterar o valor de um produto
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool AlterarValor(float valor)
        {
            if (ReferenceEquals(this, null) || valor <= 0.0)
                return false;

            this.Valor = valor;

            return true;
        }


        /// <summary>
        /// Metodo para alterar a garantia de um produto
        /// </summary>
        /// <param name="garantia"></param>
        /// <returns></returns>
        public bool AlterarGarantia(float garantia)
        {
            if (ReferenceEquals(this, null) || garantia <= 0.0)
                return false;

            this.garantiaAnos = garantia;

            return true;
        }


        /// <summary>
        /// Metodo para alterar a categoria de um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AlterarCategoria(int id)
        {
            if (ReferenceEquals(this, null))
                return false;

            if (!Categorias.VerificaCategoriaPorId(id))
                return false;


            this.CatgId = id;

            return true;
        }



        /// <summary>
        /// Metodo para alterar a marca de um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AlterarMarca(int id)
        {
            if (ReferenceEquals(this, null))
                return false;

            if (!Marcas.VerificaMarcaPorId(id))
                return false;


            this.MarcaId = id;

            return true;
        }


        #endregion

        #endregion

    }
}