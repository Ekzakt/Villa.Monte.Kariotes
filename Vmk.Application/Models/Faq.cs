﻿using Vmk.Application.Contracts;

namespace Vmk.Application.Models;

#nullable disable

public class Faq : AbstractModel
{
    public string Question { get; set; }

    public string Answer { get; set; }  
}
