using System;
using System.Collections.Generic;

namespace Mail.Entities;

public partial class MessagesInfo
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public DateTime? DispatchTime { get; set; }

    public int? SenderId { get; set; }

    public int? RecipientId { get; set; }

    public virtual User? Recipient { get; set; }

    public virtual User? Sender { get; set; }
}
