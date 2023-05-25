using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MSNLD_Chat_Client
{
    internal class AxControl : AxHost
    {
        internal Dictionary<string, string> Properties;

        /// <summary>
        ///  Creates a new instance of a control which wraps an activeX control given by the clsid parameter and flags
        ///  of 0.
        /// </summary>
        protected AxControl(string clsid) : this(clsid, 0)
        {
        }

        /// <summary>
        ///  Creates a new instance of a control which wraps an activeX control given by the clsid and flags parameters.
        /// </summary>
        protected AxControl(string clsid, int flags) : base(clsid, flags)
        {
            Properties = new Dictionary<string, string>();
        }

        /// <summary>
        ///  AxControl will call this when it is ready to create the underlying ActiveX object.
        ///  getOcx() should not usually be called before this function.
        ///  Note: calling begin will result in a call to this function.
        /// </summary>
        protected override void AttachInterfaces()
        {
            this.SetProperties();
            // TODO: Cast the pointer obtained by calling getOcx() to the appropriate interface.
        }

        /// <summary>
        ///  This is the default size of the control.
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(75, 23);
            }
        }

        /// <summary>
        ///  The MSN Chat Control requires most properties to be set before it's fully initialised. We do this by
        ///  utilizing a dictionary of properties and values, and then setting them all at once when the control is
        ///  created.
        ///  Some properties are able to be set after the MSN Chat control is initialised, but this is unlikely to be
        ///  very useful in real world scenarios.
        /// </summary>
        protected void SetProperties()
        {
            // TODO: Loop through BaseTypes.
            // TODO: Check for null references.
            var PropertyBagType = this.GetType().BaseType.BaseType.GetNestedType("PropertyBagStream", BindingFlags.NonPublic);
            var PropertyBag = Activator.CreateInstance(PropertyBagType);

            var writeMethod = PropertyBagType.GetMethod("Interop.Oleaut32.IPropertyBag.Write", BindingFlags.Instance | BindingFlags.NonPublic);
            if (writeMethod != null)
            {
                var parameters = writeMethod.GetParameters();

                foreach (var Property in Properties)
                {
                    if (String.IsNullOrWhiteSpace(Property.Value)) continue; // Skip null values
                    var parametersArray = new object[] { Property.Key, Property.Value };
                    writeMethod.Invoke(PropertyBag, parametersArray);
                }
            }
            var State = Activator.CreateInstance(typeof(AxHost.State), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { PropertyBag }, null);
            OcxState = State as State;
        }
    }
}
