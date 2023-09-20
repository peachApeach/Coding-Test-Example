/*
[문제]
얀에서는 매년 달리기 경주가 열립니다. 해설진들은 선수들이 자기 바로 앞의 선수를 추월할 때 추월한 선수의 이름을 부릅니다. 예를 들어 1등부터 3등까지 "mumu", "soe", "poe" 선수들이 순서대로 달리고 있을 때, 해설진이 "soe"선수를 불렀다면 2등인 "soe" 선수가 1등인 "mumu" 선수를 추월했다는 것입니다. 즉 "soe" 선수가 1등, "mumu" 선수가 2등으로 바뀝니다.
선수들의 이름이 1등부터 현재 등수 순서대로 담긴 문자열 배열 players와 해설진이 부른 이름을 담은 문자열 배열 callings가 매개변수로 주어질 때, 경주가 끝났을 때 선수들의 이름을 1등부터 등수 순서대로 배열에 담아 return 하는 solution 함수를 완성해주세요.

[제한사항]
- 5 ≤ players의 길이 ≤ 50,000
    - players[i]는 i번째 선수의 이름을 의미합니다.
    - players의 원소들은 알파벳 소문자로만 이루어져 있습니다.
    - players에는 중복된 값이 들어가 있지 않습니다.
    - 3 ≤ players[i]의 길이 ≤ 10
- 2 ≤ callings의 길이 ≤ 1,000,000
    - callings는 players의 원소들로만 이루어져 있습니다.
    - 경주 진행중 1등인 선수의 이름은 불리지 않습니다.

[예시]
players = ["mumu", "soe", "poe", "kai", "mine"]
callings = ["kai", "kai", "mine", "mine"]
result = ["mumu", "kai", "mine", "soe", "poe"]

*/

using System;
using System.Collections.Generic;

public class Solution {
    public string[] solution(string[] players, string[] callings) {
        // 반복적으로 호출될 경우 시간복잡도가 높아지므로 큰 배열에서 반복저긍로 호출 시 성능 문제 발생
        /*
        List<string> answer = new List<string>(players);
        
        for(int i=0; i<callings.Length; i++)
            {
                int index = answer.IndexOf(callings[i]);
                answer.RemoveAt(index);
                answer.Insert(index-1, callings[i]);
            }
        
        return answer.ToArray();
        */

        // 시간 복잡도를 고려한 효율적인 방법은 Dictionary를 사용하는 것
        Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < players.Length; i++)
                dict.Add(players[i], i); // 키 값에 대한 순위

            for (int i = 0; i < callings.Length; i++)
            {
                int num = dict[callings[i]]--; // 현재 순위 + 1
                string str = players[num - 1]; // 추월 당하는 플레이어

                players[num - 1] = players[num];
                players[num] = str;

                dict[str]++;
            }

            return players;
    }
}