
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-feature-material-table',
  template: `
  <h2>Feature Flags</h2>

  <table mat-table [dataSource]="dataSource" matSort>

    <ng-container matColumnDef="key">
      <th mat-header-cell *matHeaderCellDef mat-sort-header> Key </th>
      <td mat-cell *matCellDef="let element"> {{element.key}} </td>
    </ng-container>

    <ng-container matColumnDef="description">
      <th mat-header-cell *matHeaderCellDef mat-sort-header> Description </th>
      <td mat-cell *matCellDef="let element"> {{element.description}} </td>
    </ng-container>

    <ng-container matColumnDef="enabled">
      <th mat-header-cell *matHeaderCellDef mat-sort-header> Enabled </th>
      <td mat-cell *matCellDef="let element"> {{element.enabled}} </td>
    </ng-container>

    <tr mat-header-row *matHeaderRowDef="displayedColumns"></tr>
    <tr mat-row *matRowDef="let row; columns: displayedColumns;"></tr>
  </table>

  <mat-paginator [pageSize]="5"></mat-paginator>
  `
})
export class FeatureMaterialTableComponent implements AfterViewInit {
  displayedColumns: string[] = ['key','description','enabled'];
  dataSource = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
