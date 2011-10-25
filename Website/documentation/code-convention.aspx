﻿<%@ Page Title="Code Conventions" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="code-convention.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>


<asp:Content ID="Title" ContentPlaceHolderID="Title" Runat="Server">
    <strong runat="server" id="PageTitle"></strong> ‹ Documentation ‹ <a href="/">Graphite</a>
</asp:Content>



<asp:Content ID="Header" ContentPlaceHolderID="Header" Runat="Server">
    
</asp:Content>



<asp:Content ID="Intro" ContentPlaceHolderID="Intro" Runat="Server">
    <div class="gp_block gp_text">
        <article>
            <h1>Code Conventions in Graphite</h1>
            <p><big>Consistent coding improves readability and the quality of Graphite in general. Here below you can find the code conventions it adheres to.</big></p>
        </article>
    </div>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="Todo" Runat="Server">
</asp:Content>



<asp:Content ID="Column3_1" ContentPlaceHolderID="Column3_1" Runat="Server">
    <div class="gp_block gp_text">
        <article>
            <h1 class="heading2">HTML</h1>
        </article>
    </div>
</asp:Content>



<asp:Content ID="Column3_2" ContentPlaceHolderID="Column3_2" Runat="Server">
    <div class="gp_block gp_text">
        <article>
            <h1 class="heading2">CSS</h1>
            <ul>
                <li>
                    <strong>All classes are prefixed with <code>gp_</code></strong><br />
                    This will minimize the risk of collission with other CSS code.
                </li>
            </ul>
        </article>
    </div>
</asp:Content>



<asp:Content ID="Column3_3" ContentPlaceHolderID="Column3_3" Runat="Server">
    <div class="gp_block gp_text">
        <article>
            <h1 class="heading2">JavaScript</h1>
        </article>
    </div>
</asp:Content>
