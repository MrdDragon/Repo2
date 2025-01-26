//-----------------------------------------------------------------
//    <copyright file="Connecao.cs"    company="IPCA">
//     Copyright (c) IPCA-EST 2024. All rights reserved.
//    </copyright>
//    <date>2024-11-22</date>
//    <time>22:05</time>
//    <version>0.1</version>
//    <author>Daniel.O & Andreia.M</author>
//    <description>FocusSports</description>
//-----------------------------------------------------------------
using System.Configuration;

namespace FocusSports
{
    public class Connecao
    {
        public static string GetConString()
        {
            // Substitua "FocuSDB" pelo nome que você usou no App.config
            return ConfigurationManager.ConnectionStrings["FocuSDB"].ConnectionString;
        }

    }
}
