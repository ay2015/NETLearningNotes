using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.NetworkModels
{
    /// <summary>
    /// 突触,它是一种将一个神经元连接到另外一个神经元，已经容纳权重和权重增量的容器
    /// </summary>
    public class synapse
    {
        #region  -- Properties --
        /// <summary>
        ///   Gets or sets the identifier.
        ///   读取或设置这个标识。
        /// </summary>
        public Guid Id { get; set; }

       
        #endregion
    }
}
