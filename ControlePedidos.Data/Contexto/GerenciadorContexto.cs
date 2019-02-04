using ControlePedidos.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ControlePedidos.Infra.Data.Contexto
{
    
        public class GerenciadorContexto : IContextManager
        {
            private const string ContextKey = "ContextManager.Context";

            public ControlePedidoContexto GetContext()
            {
                if (HttpContext.Current.Items[ContextKey] == null)
                {
                    HttpContext.Current.Items[ContextKey] = new ControlePedidoContexto();
                }
                return (ControlePedidoContexto)HttpContext.Current.Items[ContextKey];
            }
        }
    }

