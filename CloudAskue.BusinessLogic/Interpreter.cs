using System;

namespace Complex
{
    /// <summary>
    /// It's interpretation the complex expression string to the simply complex number.
    /// </summary>
    public class Interpreter
    {
        public Interpreter()
        {
        }

        /// <summary>
        /// It's main method for interpretation the complex expression string to the simply complex number.
        /// </summary>
        /// <param name="expression">The complex expression string.</param>
        /// <returns>The complex number.</returns>
        public static Complex CalcExpression(string expression)
        {
            expression = expression.ToLower();
            expression = expression.Replace(" ", "");//Delete the space
            expression = expression.Replace(".", ",");
            expression = expression.Replace("pi", Math.PI.ToString());
            Complex result = CalcStandartExpression(expression);
            if (Complex.Im(result) == 0)
                return Complex.Re(result);
            else
                return result;
        }

        private static Complex CalcStandartExpression(string e)
        {
            if (e == null || e == "")
                return 0;
            int firstClose = 0;
            int closed = 0;
            string[] v = new string[1000];
            int vIndex = -1;
            int pos;

            // If the first char is '-' then insert below '0'. 
            if (e[0] == '-')
                e = e.Insert(0, "0");

            //Copy all brackets in vars. 
            for (int i = e.Length - 1; i >= 0; i--)
            {
                if (e[i] == ')')
                    if (closed++ == 0)
                        firstClose = i;
                if (e[i] == '(')
                    if (--closed == 0)
                    {
                        v[++vIndex] = e.Substring(i + 1, (firstClose - i) - 1);
                        e = e.Remove(i, (firstClose - i) + 1);
                        e = e.Insert(i, "v" + vIndex.ToString("d3"));
                    }
            }

            //Calculation all vars
            for (int i = 0; i <= vIndex; i++)
            {
                v[i] = CalcStandartExpression(v[i]).ToString();
            }

            //We have not brascets in the e further.

            //Find function and calc them.
            string func;








            func = "mod";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Mod(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "abs";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Mod(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "sign";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Sign(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "zero";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Zero(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }



            func = "exp";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Exp(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "ln";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Ln(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "sqrt";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Sqrt(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "sin";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Sin(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "cos";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Cos(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "tg";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Tg(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "ctg";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Ctg(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "arcsin";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Arcsin(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "arccos";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Arccos(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }


            func = "sin";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Sin(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "cos";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Cos(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "tg";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Tg(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "sin";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Sin(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "cos";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Cos(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "tg";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Tg(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "sh";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Sh(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "ch";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Ch(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "tgh";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Tgh(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "ctgh";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Ctgh(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "angle";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Angle(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "re";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Re(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }

            func = "im";
            pos = e.LastIndexOf(func);
            while (pos >= 0)
            {
                vIndex = Convert.ToInt32(e.Substring(pos + func.Length + 1, 3));
                e = e.Remove(pos, func.Length + 4);
                Complex res = Complex.Im(Complex.ToComplex(v[vIndex]));
                e = e.Insert(pos, res.ToString());
                pos = e.LastIndexOf(func);
            }


            //Calculation all vars
            for (int i = 0; i <= vIndex; i++)
            {
                if (v[i][0] == '-')
                    v[i] = v[i].Replace("-", "@");
                string old = "v" + String.Format("{0:d3}", i);
                e = e.Replace(old, v[i]);
            }


            func = "and";
            pos = e.LastIndexOf(func);
            if (pos >= 0)
            {
                string f = e.Replace("{", "").Replace("}", "").Replace("and", "");
                string[] vars = f.Split('|');
                double a = Double.Parse(vars[0]);
                double b = Double.Parse(vars[1]);
                double c = Double.Parse(vars[2]);
                if ((a * b) > 0)
                    return c;
                else
                    return 0;
            }

            func = "gt";
            pos = e.LastIndexOf(func);
            if (pos >= 0)
            {
                string f = e.Replace("{", "").Replace("}", "").Replace("gt", "");

                string[] vars = f.Split('|');
                double a = Double.Parse(vars[0]);
                double b = Double.Parse(vars[1]);
                double c = Double.Parse(vars[2]);
                double d = 0;
                if ((vars[3].Length > 0) && (vars[3] != "v000"))
                    d = Double.Parse(vars[3]);
                if (a > b)
                    return c;
                else
                {
                    if ((vars[3].Length > 0) && (vars[3] != "v000"))
                        return d;
                }

            }
            func = "lt";
            pos = e.LastIndexOf(func);
            if (pos >= 0)
            {
                string f = e.Replace("{", "").Replace("}", "").Replace("lt", "");

                string[] vars = f.Split('|');
                double a = Double.Parse(vars[0]);
                double b = Double.Parse(vars[1]);
                double c = Double.Parse(vars[2]);
                double d = 0;
                if ((vars[3].Length > 0) && (vars[3] != "v000"))
                    d = Double.Parse(vars[3]);
                if (a < b)
                    return c;
                else
                {
                    if ((vars[3].Length > 0) && (vars[3] != "v000"))
                        return d;
                }

            }
            func = "gte";
            pos = e.LastIndexOf(func);
            if (pos >= 0)
            {
                string f = e.Replace("{", "").Replace("}", "").Replace("gte", "");

                string[] vars = f.Split('|');
                double a = Double.Parse(vars[0]);
                double b = Double.Parse(vars[1]);
                double c = Double.Parse(vars[2]);
                double d = 0;
                if ((vars[3].Length > 0) && (vars[3] != "v000"))
                    d = Double.Parse(vars[3]);
                if (a >= b)
                    return c;
                else
                {
                    if ((vars[3].Length > 0) && (vars[3] != "v000"))
                        return d;
                }

            }
            func = "lte";
            pos = e.LastIndexOf(func);
            if (pos >= 0)
            {
                string f = e.Replace("{", "").Replace("}", "").Replace("lte", "");

                string[] vars = f.Split('|');
                double a = Double.Parse(vars[0]);
                double b = Double.Parse(vars[1]);
                double c = Double.Parse(vars[2]);
                double d = 0;
                if ((vars[3].Length > 0) && (vars[3] != "v000"))
                    d = Double.Parse(vars[3]);
                if (a <= b)
                    return c;
                else
                {
                    if ((vars[3].Length > 0) && (vars[3] != "v000"))
                        return d;
                }

            }
            func = "equal";
            pos = e.LastIndexOf(func);
            if (pos >= 0)
            {
                string f = e.Replace("{", "").Replace("}", "").Replace("equal", "");

                string[] vars = f.Split('|');
                double a = Double.Parse(vars[0]);
                double b = Double.Parse(vars[1]);
                double c = Double.Parse(vars[2]);
                double d = 0;
                if ((vars[3].Length > 0) && (vars[3] != "v000"))
                    d = Double.Parse(vars[3]);
                if (a == b)
                    return c;
                else
                {
                    if ((vars[3].Length > 0) && (vars[3] != "v000"))
                        return d;
                }

            }

            //Do operators
            e = e.ToLower();
            string op1;
            string op2;
            Complex ComplexOp1;
            Complex ComplexOp2;



            //Do sum
            pos = Pos(e, '+');
            if (pos > 0)
            {
                op1 = e.Substring(0, pos);
                if (op1.Length == 4 && op1[0] == 'v')
                    op1 = v[Convert.ToInt32(op1.Substring(1, 3))];
                op2 = e.Substring(pos + 1, e.Length - pos - 1);
                if (op2.Length == 4 && op2[0] == 'v')
                    op2 = v[Convert.ToInt32(op2.Substring(1, 3))];
                op1 = op1.Replace("@", "-");
                op2 = op2.Replace("@", "-");
                ComplexOp1 = CalcStandartExpression(op1);
                ComplexOp2 = CalcStandartExpression(op2);
                return ComplexOp1 + ComplexOp2;
            }

            //Do subtraction
            pos = Pos(e, '-');
            if (pos > 0)
            {
                op1 = e.Substring(0, pos);
                if (op1.Length == 4 && op1[0] == 'v')
                    op1 = v[Convert.ToInt32(op1.Substring(1, 3))];
                op2 = e.Substring(pos + 1, e.Length - pos - 1);
                if (op2.Length == 4 && op2[0] == 'v')
                    op2 = v[Convert.ToInt32(op2.Substring(1, 3))];
                op1 = op1.Replace("@", "-");
                op2 = op2.Replace("@", "-");
                ComplexOp1 = CalcStandartExpression(op1);
                ComplexOp2 = CalcStandartExpression(op2);
                return ComplexOp1 - ComplexOp2;
            }

            //Do multiply
            pos = e.LastIndexOf("*");
            if (pos >= 0)
            {
                op1 = e.Substring(0, pos);
                if (op1.Length == 4 && op1[0] == 'v')
                    op1 = v[Convert.ToInt32(op1.Substring(1, 3))];
                op2 = e.Substring(pos + 1, e.Length - pos - 1);
                if (op2.Length == 4 && op2[0] == 'v')
                    op2 = v[Convert.ToInt32(op2.Substring(1, 3))];
                op1 = op1.Replace("@", "-");
                op2 = op2.Replace("@", "-");
                ComplexOp1 = CalcStandartExpression(op1);
                ComplexOp2 = CalcStandartExpression(op2);
                return ComplexOp1 * ComplexOp2;
            }

            //Do divide
            pos = e.LastIndexOf("/");
            if (pos >= 0)
            {
                op1 = e.Substring(0, pos);
                if (op1.Length == 4 && op1[0] == 'v')
                    op1 = v[Convert.ToInt32(op1.Substring(1, 3))];
                op2 = e.Substring(pos + 1, e.Length - pos - 1);
                if (op2.Length == 4 && op2[0] == 'v')
                    op2 = v[Convert.ToInt32(op2.Substring(1, 3))];
                op1 = op1.Replace("@", "-");
                op2 = op2.Replace("@", "-");
                ComplexOp1 = CalcStandartExpression(op1);
                ComplexOp2 = CalcStandartExpression(op2);
                return ComplexOp1 / ComplexOp2;
            }

            //Do power
            pos = -1;
            for (int i = 1; i <= e.Length - 1; i++)
                if (e[i] == '^')
                {
                    pos = i;
                    break;
                };
            if (pos >= 0)
            {
                op1 = e.Substring(0, pos);
                if (op1.Length == 4 && op1[0] == 'v')
                    op1 = v[Convert.ToInt32(op1.Substring(1, 3))];
                op2 = e.Substring(pos + 1, e.Length - pos - 1);
                if (op2.Length == 4 && op2[0] == 'v')
                    op2 = v[Convert.ToInt32(op2.Substring(1, 3))];
                op1 = op1.Replace("@", "-");
                op2 = op2.Replace("@", "-");
                ComplexOp1 = CalcStandartExpression(op1);
                ComplexOp2 = CalcStandartExpression(op2);
                return Complex.Pow(ComplexOp1, ComplexOp2);
            }

            Complex result = Complex.ToComplex(e);
            return result;
        }

        private static int Pos(string s, char c)
        {
            for (int i = s.Length - 1; i > 0; i--)
                if (s[i] == c && s[i - 1] != 'e')
                    return i;
            return -1;

        }
    }
}
