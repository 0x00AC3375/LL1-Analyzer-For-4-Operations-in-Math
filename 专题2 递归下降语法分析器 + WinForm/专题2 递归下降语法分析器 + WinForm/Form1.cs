using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace 专题2_递归下降语法分析器___WinForm
{
	public partial class ExpressionParser : Form
	{
		public ExpressionParser()
		{
			InitializeComponent();
			KeyPreview = true;
			BasicOutput.KeyDown += new KeyEventHandler(Task2_KeyDown!);
			BasicOutput.MouseWheel += new MouseEventHandler(Task2_MouseWheel!);
			FormattedInput.KeyDown += new KeyEventHandler(Task2_KeyDown!);
			FormattedInput.MouseWheel += new MouseEventHandler(Task2_MouseWheel!);
			DetailedOutput.KeyDown += new KeyEventHandler(Task2_KeyDown!);
			DetailedOutput.MouseWheel += new MouseEventHandler(Task2_MouseWheel!);
			InputBox.KeyDown += new KeyEventHandler(Task2_KeyDown!);
			InputBox.MouseWheel += new MouseEventHandler(Task2_MouseWheel!);
			MouseWheel += new MouseEventHandler(Task2_MouseWheel!);
		}

		// LL1分析表
		public static readonly Dictionary<Tuple<char, char>, Tuple<char, string>>? LL1Table = new() {
			// 所有推导出i的符号以及对应的产生式
			{ new Tuple<char, char>('E', 'i'), new Tuple<char, string>('E', "Te") },
			{ new Tuple<char, char>('T', 'i'), new Tuple<char, string>('T', "Ft") },
			{ new Tuple<char, char>('F', 'i'), new Tuple<char, string>('F', "i") },
			// 所有推导出+的符号以及对应的产生式
			{ new Tuple<char, char>('e', '+'), new Tuple<char, string>('e', "ATe") },
			{ new Tuple<char, char>('t', '+'), new Tuple<char, string>('t', string.Empty) },
			{ new Tuple<char, char>('A', '+'), new Tuple<char, string>('A', "+") },
			// 所有推导出-的符号以及对应的产生式
			{ new Tuple<char, char>('e', '-'), new Tuple<char, string>('e', "ATe") },
			{ new Tuple<char, char>('t', '-'), new Tuple<char, string>('t', string.Empty) },
			{ new Tuple<char, char>('A', '-'), new Tuple<char, string>('A', "-") },
			// 所有推导出*的符号以及对应的产生式
			{ new Tuple<char, char>('t', '*'), new Tuple<char, string>('t', "MFt") },
			{ new Tuple<char, char>('M', '*'), new Tuple<char, string>('M', "*") },
			// 所有推导出/的符号以及对应的产生式
			{ new Tuple<char, char>('t', '/'), new Tuple<char, string>('t', "MFt") },
			{ new Tuple<char, char>('M', '/'), new Tuple<char, string>('M', "/") },
			// 左括号和右括号
			{ new Tuple<char, char>('E', '('), new Tuple<char, string>('E', "Te") },
			{ new Tuple<char, char>('T', '('), new Tuple<char, string>('T', "Ft") },
			{ new Tuple<char, char>('F', '('), new Tuple<char, string>('F', "(E)") },
			{ new Tuple<char, char>('e', ')'), new Tuple<char, string>('e', string.Empty) },
			{ new Tuple<char, char>('t', ')'), new Tuple<char, string>('t', string.Empty) },
			// 终结符
			{ new Tuple<char, char>('e', '#'), new Tuple<char, string>('e', string.Empty) },
			{ new Tuple<char, char>('t', '#'), new Tuple<char, string>('t', string.Empty) },
			// 负数(待补充)
		};

		List<string> step_pages = new();
		int current_page = 0;

		void Run(object sender, EventArgs e)
		{
			// 清空已有的内容
			string raw_input = InputBox.Text;
			BasicOutput.Text = string.Empty;
			DetailedOutput.Text = string.Empty;
			// 启用控件
			Previous.Enabled = true;
			Next.Enabled = true;
			if (raw_input == null) Environment.Exit(0);
			else
			{
				// 清空已有的内容
				step_pages = new();
				// 计时
				decimal start = DateTime.Now.Ticks;
				// 去除空格和制表符
				raw_input = raw_input.Replace(" ", "").Replace("\t", "").Replace("\r", "").Replace("\n", "");
				if (string.IsNullOrWhiteSpace(raw_input))
				{
					MessageBox.Show("Input cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				// 末尾是小数点则这个小数点是无用的
				if (raw_input[^1] == '.') raw_input = raw_input[0..(raw_input.Length - 1)];
				// 转化为语法分析器范式
				string syntax_format = Regex.Replace(raw_input.Replace(".", ""), @"\d+(\.\d+)*", "i");
				// 将所有出现的数字全部转化为decimal类型
				string decimal_format = Regex.Replace(
					// 移除无用的小数点
					raw_input.Replace(".-", "-").Replace(".+", "+").Replace(".*", "*").Replace("./", "/").Replace(".)", ")"),
					@"\d+(\.\d+)*", "$&m");
				FormattedInput.Text = syntax_format;
				// 语法分析
				Stack<char> remaining = new Stack<char>();
				Stack<char> analysis = new Stack<char>();
				remaining.Push('#');
				analysis.Push('#');
				analysis.Push('E');
				for (int i = syntax_format.Length - 1; i >= 0; i--) remaining.Push(syntax_format[i]);
				// 推导所需的步数
				int step = 0;
				// 当前是否合法的标志
				bool flag = true;
				// 开始分析
				while (true)
				{
					// 记录当前分析的情况
					step++;
					step_pages.Add(
						$"Step: {step}" + Environment.NewLine +
						$"Analysis stack:  {new string(string.Join(' ', analysis).Reverse().ToArray())}" + Environment.NewLine +
						$"Remaining stack: {new string(string.Join(' ', remaining).Reverse().ToArray())}");
					char input_top = remaining.Peek();
					char analysis_top = analysis.Peek();
					// 顶端终结符匹配就将其消除
					if (input_top == analysis_top && input_top != '#')
					{
						remaining.Pop();
						analysis.Pop();
					}
					// 顶端非终结符匹配，就根据分析表找到对应的产生式，并逆序入栈
					else if (LL1Table!.ContainsKey(new Tuple<char, char>(analysis_top, input_top)))
					{
						Tuple<char, string>? production = LL1Table[new Tuple<char, char>(analysis_top, input_top)];
						analysis.Pop();
						if (production!.Item2 != string.Empty)
						{
							for (int i = production.Item2.Length - 1; i >= 0; i--) analysis.Push(production.Item2[i]);
						}
					}
					// 终结符与非终结符不匹配，则报错
					else
					{
						BasicOutput.Text = $"Error detected after {step} step(s) while parsing input string.";
						flag = false;
						break;
					}
					if (remaining.Count == 1 && analysis.Count == 1)
					{
						step++;
						step_pages.Add(
							$"Step: {step}" + Environment.NewLine +
							$"Analysis stack:  {new string(string.Join(' ', analysis).Reverse().ToArray())}" + Environment.NewLine +
							$"Remaining stack: {new string(string.Join(' ', remaining).Reverse().ToArray())}");

						break;
					}
				}
				if (flag)
				{
					BasicOutput.Text += $"Parse successful - {step} step(s) in total.";
				}

				string error_message = string.Empty;
				try // 表达式求值
				{
					object? numerical_result = new Flee.PublicTypes.ExpressionContext().CompileDynamic(decimal_format).Evaluate();
					BasicOutput.Text += Environment.NewLine + $"The mathematical result of the expression is: {numerical_result}\n";
				}
				catch (Exception ex) // 求值阶段发现错误
				{
					BasicOutput.Text += Environment.NewLine + "Error detected while calculating the expression.";
					error_message = ex.Message;
				}
				decimal end = DateTime.Now.Ticks;
				BasicOutput.Text += Environment.NewLine + $"Time used: {(end - start) * 0.0000001m:N3} seconds.";
				if (string.IsNullOrEmpty(error_message) == false)
				{
					MessageBox.Show(error_message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				DetailedOutput.Text = step_pages[0];
				current_page = 0;
				return;
			}
		}

		private void ViewPages(object sender, EventArgs e)
		{
			if (current_page == 0)
			{
				Previous.Enabled = false;
			}
			if (current_page == step_pages.Count - 1)
			{
				Next.Enabled = false;
			}

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void PreviousClick(object sender, EventArgs e)
		{
			if (current_page > 0)
			{
				current_page--;
				DetailedOutput.Text = step_pages[current_page];
			}
		}

		private void NextClick(object sender, EventArgs e)
		{
			if (current_page < step_pages.Count - 1)
			{
				current_page++;
				DetailedOutput.Text = step_pages[current_page];
			}
		}

		private void AnalysisClick(object sender, EventArgs e)
		{
			Run(sender, e);
		}

		private void ResetClick(object sender, EventArgs e)
		{
			current_page = 0;
			step_pages.Clear();
			BasicOutput.Text = string.Empty;
			DetailedOutput.Text = string.Empty;
			InputBox.Text = string.Empty;
			FormattedInput.Text = string.Empty;
			Previous.Enabled = false;
			Next.Enabled = false;
		}

		private void Task2LeftPress(object sender, KeyEventArgs e)
		{
			PreviousClick(sender, e);
		}

		private void Task2RightPress(object sender, KeyEventArgs e)
		{
			NextClick(sender, e);
		}

		private void Task2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
			{
				Task2LeftPress(sender, e);
			}
			else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
			{
				Task2RightPress(sender, e);
			}
			else if (e.KeyCode == Keys.Escape)
			{
				ResetClick(sender, e);
			}
			else if (e.KeyCode == Keys.Enter)
			{
				Run(sender, e);
			}
		}

		private void Task2_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta > 0)
			{
				NextClick(sender, e);
			}
			else
			{
				PreviousClick(sender, e);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
		}

		private void button4_Click(object sender, EventArgs e)
		{
		}
	}
}