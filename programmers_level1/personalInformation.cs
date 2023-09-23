/*
[문제]
https://school.programmers.co.kr/learn/courses/30/lessons/150370
고객의 약관 동의를 얻어서 수집된 1~n번으로 분류되는 개인정보 n개가 있습니다. 약관 종류는 여러 가지 있으며 각 약관마다 개인정보 보관 유효기간이 정해져 있습니다. 당신은 각 개인정보가 어떤 약관으로 수집됐는지 알고 있습니다. 수집된 개인정보는 유효기간 전까지만 보관 가능하며, 유효기간이 지났다면 반드시 파기해야 합니다.
예를 들어, A라는 약관의 유효기간이 12 달이고, 2021년 1월 5일에 수집된 개인정보가 A약관으로 수집되었다면 해당 개인정보는 2022년 1월 4일까지 보관 가능하며 2022년 1월 5일부터 파기해야 할 개인정보입니다.
당신은 오늘 날짜로 파기해야 할 개인정보 번호들을 구하려 합니다.

[예시]
today = "2022.05.19"
terms = ["A 6", "B 12", "C 3"]
privacies = ["2021.05.02 A", "2021.07.01 B", "2022.02.19 C", "2022.02.20 C"]
result = [1, 3]
*/

using System;
using System.Collections.Generic; 

public class Solution {
    public int[] solution(string today, string[] terms, string[] privacies) {
        List<int> answer = new List<int>();
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string str="";
        string[] parts = new string[] {};
        
        for(int i=0; i< terms.Length; i++){
            str = terms[i];
            parts = str.Split(' ');
            dict.Add(parts[0], int.Parse(parts[1]));
        }
        
        DateTime date = DateTime.Parse(today);
        
        for(int i=0; i<privacies.Length; i++){
            str = privacies[i];
            parts = str.Split(' ');
            
            if (date >= DateTime.Parse(parts[0]).AddMonths(dict[parts[1]]))
            {
                answer.Add(i+1);
            }
        }
        
        
        return answer.ToArray();
    }
}