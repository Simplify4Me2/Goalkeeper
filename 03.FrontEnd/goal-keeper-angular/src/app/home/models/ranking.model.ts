import { TeamRanking } from "./team-ranking.model";

export interface Ranking {
    competitionName: string;
    teamRankings: TeamRanking[];
}