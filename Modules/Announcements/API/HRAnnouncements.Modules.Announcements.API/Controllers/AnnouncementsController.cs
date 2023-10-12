using HRAnnouncements.Modules.Announcements.Application.Commands.Implementations;
using HRAnnouncements.Modules.Announcements.Application.Queries.Implementations;
using HRAnnouncements.Modules.Announcements.Domain.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRAnnouncements.Modules.Announcements.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AnnouncementsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnnouncementsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]    
    public async Task<IActionResult> GetAnnouncements([FromQuery] AnnouncementFilter filter)
    {
        var query = new GetAnnouncementsQuery { Filter = filter };
        var announcementListDtos = await _mediator.Send(query);
        return Ok(announcementListDtos);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnnouncement(Guid id)
    {
        var query = new GetAnnouncementQuery { Id = id };
        var announcementDto = await _mediator.Send(query);

        if (announcementDto == null)
            return NotFound();

        return Ok(announcementDto);
    }

    [HttpGet("{announcementId}/comments")]
    public async Task<IActionResult> GetAnnouncementComments(Guid announcementId)
    {
        var query = new GetCommentsByAnnouncementQuery(announcementId);
        var commentsListDtos = await _mediator.Send(query);

        if (!commentsListDtos.Any())
            return NotFound();

        return Ok(commentsListDtos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAnnouncementCommand command)
    {
        var announcementId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAnnouncement), new { id = announcementId }, command);
    }

    [HttpPost("{announcementId}/comments")]
    public async Task<IActionResult> AddComment(Guid announcementId, [FromBody] CreateAnnouncementCommentCommand command)
    {
        command.AnnouncementId = announcementId;
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPatch("{id}/like")]
    public async Task<IActionResult> LikeAnnouncement(Guid id)
    {
        await _mediator.Send(new LikeAnnouncementCommand { Id = id });
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAnnouncement(Guid id, UpdateAnnouncementCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnnouncement(Guid id)
    {
        await _mediator.Send(new DeleteAnnouncementCommand { Id = id });
        return NoContent();
    }
}
