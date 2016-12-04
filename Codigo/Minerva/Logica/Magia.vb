Imports MySql.Data.MySqlClient

Public Class Magia
    Dim max_horas_diarias As Integer = 7
    Dim materias_auxiliares(1) As Array
    Dim materias_ordenadas(1) As Array
    Dim asignacionLunes(1) As String
    Dim asignacionMartes(1) As String
    Dim asignacionMiercoles(1) As String
    Dim asignacionJueves(1) As String
    Dim asignacionViernes(1) As String
    Dim asignacionSabado(1) As String

    Private Sub CargarMateriasAsignacion(frm As frmAdminGrupos)
        Dim resultadosPersistencia As Object = InformacionDB.GetAsignaturasReparticion(frm.txtIdGrupo.Text, frm.cboGrado.Text)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)
        Dim pos As Integer = 0
        While reader.Read()
            materias_auxiliares(pos) = {reader("IdAsignatura"), reader("CargaHoraria"), reader("EnseniaDeCorrido")}
            pos += 1
            ReDim Preserve materias_auxiliares(pos + 1)
        End While
        reader.Close()

        ReDim Preserve materias_auxiliares(pos - 1)
    End Sub

    Private Sub CrearModulos()
        Dim pos As Integer = 0

        For Each materia As Object In materias_auxiliares
            If Not materia(2) And materia(1) > 1 Then
                While materia(1) > 0
                    If materia(1) = 1 Then
                        materia = {materia(0), 0, False}
                        materias_ordenadas(pos) = {materia(0), 1, "-"}

                    ElseIf materia(1) = 2 Then
                        materia = {materia(0), 0, False}
                        materias_ordenadas(pos) = {materia(0), 2, "-"}

                    Else
                        materia = {materia(0), materia(1) - 2, False}
                        materias_ordenadas(pos) = {materia(0), 2, "-"}
                    End If

                    pos += 1
                    ReDim Preserve materias_ordenadas(pos + 1)
                End While
            ElseIf materia(2) Then
                materias_ordenadas(pos) = {materia(0), materia(1), "--"}
                pos += 1

                ReDim Preserve materias_ordenadas(pos + 1)
            End If
        Next

        ReDim Preserve materias_ordenadas(materias_ordenadas.Length - 1)
    End Sub

    Public Sub RepartirHorarios(frm As frmAdminGrupos)
        Try
            RepartirHorariosAutomagicamente(frm)
        Catch ex As Exception
            MessageBox.Show("Hubieron errores al hacer la asignación inicial de materias." & vbCrLf & "Deberá modificar las asignaturas manualmente en la pestaña horarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub RepartirHorariosAutomagicamente(frm As frmAdminGrupos)
        Dim NroGrupo As String = PersistenciaGrupos.GetNroGrupo(frm.cboGrado.Text + " " + frm.txtIdGrupo.Text)
        Dim IdTurno As String = PersistenciaGrupos.GetTurno(frm.cboGrado.Text + " " + frm.txtIdGrupo.Text)

        CargarMateriasAsignacion(frm)
        CrearModulos()

        Dim materias_asignadas(materias_ordenadas.Length) As Array

        Dim posLunes As Integer = 0
        Dim posMartes As Integer = 0
        Dim posMiercoles As Integer = 0
        Dim posJueves As Integer = 0
        Dim posViernes As Integer = 0
        Dim posSabado As Integer = 0
        Dim pos As Integer = 0

        If IdTurno = 1 Then
            posLunes = 1
            posMartes = 1
            posMiercoles = 1
            posJueves = 1
            posViernes = 1
            posSabado = 1
        End If

        For value As Integer = 0 To 50
            For Each materia As Object In materias_ordenadas
                If materias_asignadas.Contains(materia) Then
                    Continue For
                End If

                If value > 25 And Not IdTurno = 3 Then
                    max_horas_diarias = 8
                Else
                    max_horas_diarias = 7
                End If


                If max_horas_diarias > asignacionLunes.Length - 1 + materia(1) And Not asignacionLunes.Contains(materia(0)) Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionLunes(posLunes) = materia(0)
                        x += 1
                        posLunes += 1
                        ReDim Preserve asignacionLunes(posLunes)
                    End While

                    materias_asignadas(pos) = materia
                    pos += 1

                ElseIf max_horas_diarias > asignacionMartes.Length - 1 + materia(1) And Not asignacionMartes.Contains(materia(0)) Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionMartes(posMartes) = materia(0)
                        x += 1
                        posMartes += 1
                        ReDim Preserve asignacionMartes(posMartes)
                    End While

                    materias_asignadas(pos) = materia
                    pos += 1

                ElseIf max_horas_diarias > asignacionMiercoles.Length - 1 + materia(1) And Not asignacionMiercoles.Contains(materia(0)) Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionMiercoles(posMiercoles) = materia(0)
                        x += 1
                        posMiercoles += 1
                        ReDim Preserve asignacionMiercoles(posMiercoles)
                    End While

                    materias_asignadas(pos) = materia
                    pos += 1

                ElseIf max_horas_diarias > asignacionJueves.Length - 1 + materia(1) And Not asignacionJueves.Contains(materia(0)) Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionJueves(posJueves) = materia(0)
                        x += 1
                        posJueves += 1
                        ReDim Preserve asignacionJueves(posJueves)
                    End While

                    materias_asignadas(pos) = materia
                    pos += 1

                ElseIf max_horas_diarias > asignacionViernes.Length - 1 + materia(1) And Not asignacionViernes.Contains(materia(0)) Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionViernes(posViernes) = materia(0)
                        x += 1
                        posViernes += 1
                        ReDim Preserve asignacionViernes(posViernes)
                    End While

                    materias_asignadas(pos) = materia
                    pos += 1

                ElseIf max_horas_diarias > asignacionSabado.Length - 1 + materia(1) And Not asignacionSabado.Contains(materia(0)) And max_horas_diarias <= 7 Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionSabado(posSabado) = materia(0)
                        x += 1
                        posSabado += 1
                        ReDim Preserve asignacionSabado(posSabado)
                    End While

                    materias_asignadas(pos) = materia
                    pos += 1

                Else
                End If
            Next
        Next

        ReDim Preserve asignacionLunes(asignacionLunes.Length - 2)
        ReDim Preserve asignacionMartes(asignacionMartes.Length - 2)
        ReDim Preserve asignacionMiercoles(asignacionMiercoles.Length - 2)
        ReDim Preserve asignacionJueves(asignacionJueves.Length - 2)
        ReDim Preserve asignacionViernes(asignacionViernes.Length - 2)
        ReDim Preserve asignacionSabado(asignacionSabado.Length - 2)


        Dim HorariosInicio(8) As Object
        Dim HorariosFin(8) As Object

        Dim resultadosPersistencia As Object = PersistenciaHorarios.GetHorariosTurno(IdTurno)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)
        Dim posActual As Integer = 1

        While reader.Read()
            HorariosInicio(posActual) = reader("HoraInicio").ToString()
            HorariosFin(posActual) = reader("HoraFin").ToString()

            posActual += 1
        End While

        reader.Close()
        resultadosPersistencia(1).Close()

        Dim total As Integer = 0
        Dim horaActual As Integer = 1
        Dim sentencias(0) As Array
        Dim Dias As String() = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"}
        Dim Asignacion As Object = {asignacionLunes, asignacionMartes, asignacionMiercoles, asignacionJueves, asignacionViernes, asignacionSabado}

        Dim DiaActual As Integer = 0
        For Each asigna As Object In Asignacion
            horaActual = 1
            For Each item As String In asigna
                Dim Dia As String = Dias(DiaActual)
                sentencias(total) = {item, NroGrupo, HorariosInicio(horaActual), HorariosFin(horaActual), Dia, IdTurno, "-1"}

                horaActual += 1
                total += 1
                ReDim Preserve sentencias(total)
            Next
            DiaActual += 1
        Next

        ReDim Preserve sentencias(sentencias.Length - 1)
        Dim huboError = False

        For Each sentencia As Object In sentencias
            Try
                PersistenciaHorarios.Add(sentencia(0), sentencia(1), sentencia(2), sentencia(3), sentencia(4), sentencia(5), sentencia(6))
            Catch ex As Exception
            End Try
        Next

        For Each materia As Object In materias_ordenadas
            If materias_asignadas.Contains(materia) Then
                Continue For
            End If
            Try
                Dim IdAsignatura As String = materia(0)
                Throw New System.Exception("No se pueden asignar :(")
            Catch ex As Exception
                If ex.ToString().Contains("No se pueden") Then
                    Throw New System.Exception("No se pueden asignar :(")
                End If
            End Try
            Exit For
        Next

    End Sub
End Class
