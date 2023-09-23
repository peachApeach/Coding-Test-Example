/*
https://school.programmers.co.kr/learn/courses/30/lessons/118666
나만의 카카오 성격 유형 검사지를 만들려고 합니다.
성격 유형 검사는 다음과 같은 4개 지표로 성격 유형을 구분합니다. 성격은 각 지표에서 두 유형 중 하나로 결정됩니다.

지표 번호	성격 유형
1번 지표	라이언형(R), 튜브형(T)
2번 지표	콘형(C), 프로도형(F)
3번 지표	제이지형(J), 무지형(M)
4번 지표	어피치형(A), 네오형(N)

[예시]
survey = ["AN", "CF", "MJ", "RT", "NA"]
choices = [5, 3, 2, 7, 5]
result = "TCMA"
*/

using System;
using System.Collections.Generic;

public class Solution {
    
    public string solution(string[] survey, int[] choices) {
        string answer = "";
        Dictionary<string, int> dict = new Dictionary<string, int>();
        dict.Add("R", 0);
        dict.Add("T", 0);
        dict.Add("F", 0);
        dict.Add("M", 0);
        dict.Add("N", 0);
        dict.Add("C", 0);
        dict.Add("J", 0);
        dict.Add("A", 0);
        
        for (int i = 0; i < choices.Length; i++){
            string str = survey[i];
            
            if(4 < choices[i]){
                dict[str[1].ToString()] += choices[i] - 4;
            }
            else if(4 > choices[i]){
                dict[str[0].ToString()] += 4 - choices[i];
            }
        }
        
        string[] atype = {"R", "C", "J", "A"};
        string[] btype = {"T", "F", "M", "N"};
        
        for(int i=0; i<4; i++)
        {
            if(dict[atype[i]] > dict[btype[i]])
                answer += atype[i];
            else if (dict[atype[i]] < dict[btype[i]])
                answer += btype[i];
            else {
                if (string.Compare(atype[i], btype[i]) < 0)
                    answer += atype[i];
                else
                    answer += btype[i];
            }
        }
        
        
        return answer;
    }
}
