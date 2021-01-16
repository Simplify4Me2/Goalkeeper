import { Team } from "./team.model";

export interface Ranking {
    id: number;
    competitionName: string;
    teams: Team[];
}