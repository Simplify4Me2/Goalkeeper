import { FilterByPositionPipe } from './filter-by-position.pipe';

describe('FilterPipe', () => {
  it('create an instance', () => {
    const pipe = new FilterByPositionPipe();
    expect(pipe).toBeTruthy();
  });
});
