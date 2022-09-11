using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OCMS03.Infrastructure;
using OCMS03.Models.Content;
using System;

namespace OCMS03.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
            ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Medication medication, string dose, string frequency, string duration, bool morning, bool afternoon, bool evening)
        {
            base.AddItem(medication, dose, duration, frequency, morning, afternoon, evening);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Medication medication)
        {
            base.RemoveLine(medication);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}