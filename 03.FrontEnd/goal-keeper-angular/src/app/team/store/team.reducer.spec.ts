import { teamReducer } from './team.reducer';
import { Team } from '../models';
import { getTeamSuccess } from './team.actions';

describe('TeamReducer', () => {
    it('an undefined action should return the default state', () => {
        const result = teamReducer(undefined, {} as any);

        expect(result).toEqual({ team: null });
        expect(result).toMatchSnapshot();
    });

    it('getTeamSuccess action should populate the state with a team', () => {
        const team: Team = { id: 3, name: 'FC De Kampioenen', players: [] };

        const result = teamReducer(undefined, getTeamSuccess({ team }));

        expect(result).toEqual({ team });
        expect(result).toMatchSnapshot();
    });
});