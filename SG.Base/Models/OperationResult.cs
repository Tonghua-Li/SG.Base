using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SG.Base.Models {
    public class OperationResult {
        #region Members

        #endregion Members

        #region Properties
        public List<string> Errors { get; set; } = new List<string>();
        public bool IsSuccess => Errors.Count == 0;
        public bool IsFail => Errors.Count != 0;
        #endregion Properties

        #region Constructor

        #endregion Constructor

        #region Methods

        public OperationResult Add(string error) {
            if (string.IsNullOrEmpty(error)) return this;
            this.Errors.Add(error);
            return this;
        }

        public OperationResult Add(List<string> errors) {
            this.Errors.AddRange(errors.Where(s=>string.IsNullOrEmpty(s)==false));
            return this;
        }
        public static OperationResult operator +(OperationResult op1, OperationResult op2) {
            return op1.Add(op2.Errors);
        }
        #endregion Methods

        #region Others

        public override string ToString() {
            return string.Join("\r\n", Errors);
        }

        #endregion Others




    }
}