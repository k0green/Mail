using System;
using System.Collections.Generic;

namespace Mail.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<MessagesInfo> MessagesInfoRecipients { get; } = new List<MessagesInfo>();

    public virtual ICollection<MessagesInfo> MessagesInfoSenders { get; } = new List<MessagesInfo>();
}
